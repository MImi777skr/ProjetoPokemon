using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour
{
    [SerializeField] Transform[] track;
    [SerializeField] float WaitTime;
    public Animator anime;
    public Dialogo dialogo;
    // Start is called before the first frame update

    void Start()
    { 
        StartCoroutine(corrotinademovimento());
        anime = GameObject.FindGameObjectWithTag("GUI/Dialogo").GetComponent<Animator>();
    }

    IEnumerator corrotinademovimento()
    {
        for( int i = 0; i < track.Length; i++)
        {
            yield return StartCoroutine(MoveNPC(i));

            if(i >= track.Length -1)
            {
                i = -1;
            }
        }
    }
    IEnumerator MoveNPC (int numCaminho)
    {
        GetComponent<NavMeshAgent>().destination = track[numCaminho].position;
        yield return new WaitForSeconds(WaitTime);
    }


    private void OnTriggerStay(Collider other)
    {
        if( other.tag == "Player" && Input.GetButtonDown("Fire1") && FindObjectOfType<GerenciaDialogo>().isSpeaking == false)
        {
            FindObjectOfType<GerenciaDialogo>().AwakeDialogo(dialogo);
            anime.SetTrigger("Mostra");
            anime.ResetTrigger("Nmostra");
           
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            anime.SetTrigger("Nmostra");
            anime.ResetTrigger("Mostra");
        }
    }
}
