using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaDeDialogoDaBataia : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] float LPS;
    [SerializeField] Text DialogueText;
    [SerializeField] Text PPtext;
    [SerializeField] Text TypeText;
    // Start is called before the first frame update
    #region Game Objects
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject MoveSelector;
    [SerializeField] GameObject MoveDetails;
    #endregion
    #region Listas
    [SerializeField] List<Text> actionText;
    [SerializeField] List<Text> MovesTexts;
    #endregion
    [SerializeField] Color Colorida;
    [SerializeField] Color CorNormal;
    public void SetDialogue(string dialogue)
    {
        DialogueText.text = dialogue;
    }

    public IEnumerator TypeDialogue(string Dialogue)
    {
        DialogueText.text = "";
        foreach (var Letter in Dialogue.ToCharArray())
        {
            DialogueText.text += Letter;

            yield return new WaitForSeconds(LPS);

        }
    }
    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }
    public void EnableDialogueText(bool enabled)
    {
        DialogueText.enabled = enabled;
    }
    public void EnableMoveSelector(bool enabled)
    {
        MoveSelector.SetActive(enabled);
        MoveDetails.SetActive(enabled);
    }
    public void UpdateActionSelector(int Acao)
    {
        for (int i = 0; i < actionText.Count; i++)
        {
            if(i == Acao)
            {
                actionText[i].color = Colorida;
            }
            else
            {
                actionText[i].color = CorNormal;
            }
        }
    }
    public void UpdateMoveSelector(int SelectedMove, Move move)
    {
        for (int i = 0; i < MovesTexts.Count; i++)
        {
            if (i == SelectedMove)
            {
                MovesTexts[i].color = Colorida;
            }
            else
            {
                MovesTexts[i].color = CorNormal;
            }
            PPtext.text = $"PP {move.Powerpoint}/{move.moveBase.powerPoint} ";
            TypeText.text = move.moveBase.Type.ToString();
        }
    }
    public void SetMoveNames(List<Move> moves)
    {
        for(int i = 0; i < MovesTexts.Count; i++)
        {
            if (i < moves.Count)
            {
                MovesTexts[i].text = moves[i].moveBase.name;
            }
            else
            {
                MovesTexts[i].text = " ";
            }
        }
    }
}
