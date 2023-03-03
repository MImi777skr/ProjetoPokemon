using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour /* , IPlayerTriggerable*/
{
   private void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("VASCO");
        }
    }

    public void OnPlayerTriggered(Player player)
    {
        Debug.Log("PORTAL");
    }
}
