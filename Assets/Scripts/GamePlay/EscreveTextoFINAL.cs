using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class EscreveTextoFINAL : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;
    [SerializeField] Text nameNPC;
    [SerializeField] Image picNPC;
    [SerializeField] int LetterPerSecond;
    public Animator Anime;

    public event Action OnShowDialogue;
    public event Action OnCloseDialogue;

    int Currentline = 0;
    Dialogo dialogo;
    bool Istyping;
    public static EscreveTextoFINAL Instancia { get; private set; }

    private void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        Anime = GameObject.FindGameObjectWithTag("GIU/Dialogo").GetComponent<Animator>();
    }

   
}
