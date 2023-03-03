using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle }
public class GameController : MonoBehaviour
{
    [SerializeField] Player playerController;
    [SerializeField] SistemaDeBataia BattleSystem;
    [SerializeField] Camera WorldCamera;
   
    GameState estado;

    // Start is called before the first frame update
    void Start()
    {
        estado = GameState.FreeRoam;
        playerController.OnEcountered += StartBattle;
        BattleSystem.BataiaAcabou += EndBattle;
    }

    // Update is called once per frame
    void Update()
    {
        if( estado == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if( estado == GameState.Battle)
        {
            BattleSystem.HandleUpdate();
        }
    }

    void StartBattle()
    {
        estado = GameState.Battle;
        playerController.gameObject.SetActive(false);
        BattleSystem.gameObject.SetActive(true);
        WorldCamera.gameObject.SetActive(false);

        var PlayerParty = playerController.GetComponent<PokemongolParty>();
        var WildPokemnon = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildPokemon();

        BattleSystem.StartBataia(PlayerParty, WildPokemnon);
    }

    void EndBattle(bool Won)
    {
        estado = GameState.FreeRoam;
        BattleSystem.gameObject.SetActive(false);
        playerController.gameObject.SetActive(true);
        WorldCamera.gameObject.SetActive(true);
        
    }
}
