using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscreveTexto : MonoBehaviour
{
    Text UItext;
    string WriteText;
    int CharacterIndex;
    float TempoPorCharacter;
    float Timer;

    public void AddText(Text UItext, string WriteText, float TempoPorCharacter)
    {
        this.UItext = UItext;
        this.WriteText = WriteText;
        this.TempoPorCharacter = TempoPorCharacter;
        CharacterIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(UItext != null)
        {
            Timer -= Time.deltaTime;

            if(Timer <= 0)
            {
                //mostra o proximo caractere
                Timer += TempoPorCharacter;
                CharacterIndex++;
                UItext.text = WriteText.Substring(0, CharacterIndex);
            }
        }
    }
}
