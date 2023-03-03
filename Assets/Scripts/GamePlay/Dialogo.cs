using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogo
{
    public int COMODIMINUIAFONTE;
    public Sprite ImagemNpc;
    public string Name;
    [TextArea(3,10)]public string[] SentenceText;
}

