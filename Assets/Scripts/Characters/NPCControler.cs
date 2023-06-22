using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControler : MonoBehaviour, Interagiveis
{
    [SerializeField] Dialogo dialogo;
    public void Interact()
    {
        Debug.Log("INTERAGINDO...");
    }
}
