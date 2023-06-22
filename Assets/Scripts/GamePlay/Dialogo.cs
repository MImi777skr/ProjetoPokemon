using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //Basicamente Faz com que se possa copiar os atributos do script quando herdado, não só os métodos
public class Dialogo
{
    [SerializeField] int _COMODIMINUIAFONTE;
    [SerializeField] Sprite _ImagemNpc;
    [SerializeField] string _Name;
    [SerializeField] [TextArea(3,10)] List<string> _SentenceText;

    public string Name { get { return _Name; } }
    public Sprite ImagemNpc{ get { return _ImagemNpc; } }
    public int Fonte { get { return _COMODIMINUIAFONTE; } }
    public List<string> SentenceText { get { return _SentenceText; } }

}

