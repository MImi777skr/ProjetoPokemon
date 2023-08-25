using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControler : MonoBehaviour, Interagiveis
{
    SpriteAnimator spriteAnimator;

    [SerializeField] List<Sprite> SpriteList;

    [SerializeField] Dialogo dialogo;
    public void Interact()
    {
        Debug.Log("INTERAGINDO...");
    }

    public void Start()
    {
        spriteAnimator = new SpriteAnimator(SpriteList, GetComponent<SpriteRenderer>() );
    }
}
