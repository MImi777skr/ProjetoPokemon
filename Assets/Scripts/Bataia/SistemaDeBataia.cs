using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BattleState {Start, PlayerAction, PlayerMove, EnemyMove, Waiting, PartyScreen }
public class SistemaDeBataia : MonoBehaviour
{
    [SerializeField] UnitDeBataia PlayerUnit;
    [SerializeField] UnitDeBataia EnemyUnit;
    [SerializeField] HUDdaBataia PlayerHUD;
    [SerializeField] HUDdaBataia EnemyHUD;
    [SerializeField] CaixaDeDialogoDaBataia DialogueBox;
    [SerializeField] PartyScreen partyScreen;

    public event Action<bool> BataiaAcabou;

    BattleState Estado;
    int CurrenctAction;
    [SerializeField] int CurrentMove;

    PokemongolParty PlayerParty;
    Pokemongol WildPokemon;
     public void StartBataia(PokemongolParty PlayerParty, Pokemongol WildPokemon)
    {
        this.PlayerParty = PlayerParty;
        this.WildPokemon = WildPokemon;
        StartCoroutine(SetupDeBataia());
    }

    public IEnumerator SetupDeBataia()
    {
        PlayerUnit.Setup(PlayerParty.GetNextPokemon());
        EnemyUnit.Setup(WildPokemon);
        PlayerHUD.SetData(PlayerUnit.Pokemongol);
        EnemyHUD.SetData(EnemyUnit.Pokemongol);
        DialogueBox.SetMoveNames(PlayerUnit.Pokemongol.MoveList);

        yield return DialogueBox.TypeDialogue($"A wild {EnemyUnit.Pokemongol.Base.name} has appeared!");
        yield return new WaitForSeconds(1f);
        yield return DialogueBox.TypeDialogue("ESCOLHA SUA AÇÃO DE CRIA");
        yield return new WaitForSeconds(0.25f);
        PlayerAction();
    }

    void PlayerAction()
    {
        Estado = BattleState.PlayerAction;
        DialogueBox.EnableActionSelector(true);
    }
    void PlayerMove()
    {
        Estado = BattleState.PlayerMove;
        DialogueBox.EnableMoveSelector(true);
        DialogueBox.EnableDialogueText(false);
        DialogueBox.EnableActionSelector(false);
    }
    void OpenPartyScreen()
    {
        Estado = BattleState.PartyScreen;
        partyScreen.gameObject.SetActive(true);
    }
    public void HandleUpdate()
    {
        if( Estado == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        if (Estado == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
    IEnumerator PerformPlayerMove()
    {
        Estado = BattleState.Waiting;
        EnemyHUD.HpCounter1();
        var move = PlayerUnit.Pokemongol.MoveList[CurrentMove];
        yield return DialogueBox.TypeDialogue($" {PlayerUnit.Pokemongol.Base.name} used {move.moveBase.name} ");
        yield return new WaitForSeconds (1f);
        PlayerUnit.PlayAttackAnime();
        EnemyUnit.PlayHitAnime();
        yield return new WaitForSeconds(0.3f);
        var DamageDetails = EnemyUnit.Pokemongol.DanoTomado(move, PlayerUnit.Pokemongol);

        yield return ShowDamageDetails(DamageDetails);
        yield return new WaitForSeconds(0.5f);
        yield return EnemyHUD.UpdateHP();
        if ( DamageDetails.Fainted)
        {
            yield return DialogueBox.TypeDialogue($"{EnemyUnit.Pokemongol.Base.name} morreu :( ");
            EnemyUnit.PlayDyingAnimation();
            yield return new WaitForSeconds(1f);
            BataiaAcabou(true);
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }
    IEnumerator EnemyMove()
    {
        Estado = BattleState.EnemyMove;
        PlayerHUD.HpCounter1();
        var move = EnemyUnit.Pokemongol.GetRandomMove();
        yield return DialogueBox.TypeDialogue($" {EnemyUnit.Pokemongol.Base.name} used {move.moveBase.name} ");
        yield return new WaitForSeconds(1f);
        EnemyUnit.PlayAttackAnime();
        PlayerUnit.PlayHitAnime();
        yield return new WaitForSeconds(0.3f);
        var DamageDetails = PlayerUnit.Pokemongol.DanoTomado(move, EnemyUnit.Pokemongol);
        yield return ShowDamageDetails(DamageDetails);
        yield return new WaitForSeconds(0.5f);
        yield return PlayerHUD.UpdateHP();
        if (DamageDetails.Fainted)
        {
            yield return DialogueBox.TypeDialogue($"{PlayerUnit.Pokemongol.Base.name} morreu :( ");
            PlayerUnit.PlayDyingAnimation();

            yield return new WaitForSeconds(1f);

            var NextPokemongol= PlayerParty.GetNextPokemon();
            if (NextPokemongol != null)
            {
                PlayerUnit.Setup(NextPokemongol);
                PlayerHUD.SetData(NextPokemongol);

                DialogueBox.SetMoveNames(NextPokemongol.MoveList);
                yield return DialogueBox.TypeDialogue($"VAI {NextPokemongol.Base.name} CARALHO, SE N EU TO FUDIDO");
                yield return new WaitForSeconds(0.4f);
                yield return DialogueBox.TypeDialogue("ESCOLHA SUA AÇÃO DE CRIA");
                yield return new WaitForSeconds(0.5f);
                PlayerAction();


            }
            else
            {
                BataiaAcabou(true);
            }
        }
        else
        {
            PlayerAction();
            DialogueBox.EnableDialogueText(false);
        }
    }
    IEnumerator ShowDamageDetails(DetalheDano DetalheDano)
    {
        if (DetalheDano.Crit > 1)
        {
            yield return DialogueBox.TypeDialogue("Ataque crítico");
        }
        if (DetalheDano.Efetividade < 1 && DetalheDano.Efetividade > 0)
        {
            yield return DialogueBox.TypeDialogue("Pouco efetivo");
        }
        else if(DetalheDano.Efetividade == 0)
        {
            yield return DialogueBox.TypeDialogue(" Sem efeito");
        }
        else if(DetalheDano.Efetividade > 1)
        {
            yield return DialogueBox.TypeDialogue("Super efetivo");
        }
        
    }
    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (CurrenctAction < 3)
            {
                ++CurrenctAction;
            }
            else if (CurrenctAction == 3)
            {
                --CurrenctAction;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if(CurrenctAction > 0)
            {
                --CurrenctAction;
            }
            else if (CurrenctAction == 0)
            {
                ++CurrenctAction;
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (CurrenctAction < 2)
            {
                CurrenctAction += 2;
            }
            else if(CurrenctAction > 1)
            {
                CurrenctAction -= 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (CurrenctAction > 1)
            {
                CurrenctAction -= 2;
            }
            else if (CurrenctAction < 3)
            {
                CurrenctAction += 2;
            }
        }
        DialogueBox.UpdateActionSelector(CurrenctAction);
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if(CurrenctAction == 2)
            {
                PlayerMove();
            }
            if(CurrenctAction == 1)
            {
                OpenPartyScreen();
            }
        }
    }
    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurrentMove < PlayerUnit.Pokemongol.MoveList.Count - 1)
            {
                ++CurrentMove;
                
            }
            else
            {
                --CurrentMove;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CurrentMove > 0)
            {
                --CurrentMove;
            }
            else
            {
                ++CurrentMove;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrentMove < PlayerUnit.Pokemongol.MoveList.Count - 2)
            {
                CurrentMove += 2;
            }
            else
            {
                CurrentMove -= 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrentMove > 1)
            {
                CurrentMove -= 2;
            }
            else
            {
                CurrentMove +=2;
            }

        }
            DialogueBox.UpdateMoveSelector(CurrentMove, PlayerUnit.Pokemongol.MoveList[CurrentMove]);
      
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DialogueBox.EnableMoveSelector(false);
            DialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
