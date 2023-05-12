using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    #region Variáveis
    CharacterController ccPlayer;
    [SerializeField] float velocidad;
    [SerializeField] Animator anime;
    [SerializeField] Vector3 input;
    [SerializeField] bool MoveInterroga;
    [SerializeField] float[] TempoDoEncontro = new float[2];
    [SerializeField] float Timer;
    public LayerMask LayerInteragiveis;

    public event Action OnEcountered;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();
        Timer = UnityEngine.Random.Range(TempoDoEncontro[0], TempoDoEncontro[1]);
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        movimento();
        Anime();
    }

    void movimento()
    {
        ccPlayer.SimpleMove(Physics.gravity);
        Vector3 move = new Vector3((Input.GetAxisRaw("Horizontal")*-velocidad)/2.1f,0,Input.GetAxisRaw("Vertical") *-velocidad);
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        ccPlayer.Move(move * Time.deltaTime);
    }
    void Interact()
    {
        var FaceDirection = new Vector3(anime.GetFloat("Horizontal"),0,anime.GetFloat("Vertical"));
        var InteractionPos = transform.position + FaceDirection;
        Debug.DrawLine(transform.position, InteractionPos, Color.red, 3f);
    }

    #region Anime
    void Anime()
    {
        if(Input.GetButton("Vertical") ||Input.GetButton("Horizontal"))
        {
            anime.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            anime.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        }
        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            anime.SetBool("MovendoINTERROGA", false);
            MoveInterroga = false;
        }
        else
        {
            anime.SetBool("MovendoINTERROGA", true);
            MoveInterroga = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    #endregion
    #region On move over
    void OnMoveOver()
    {
        var colliders = Physics.OverlapSphere(transform.position, 0.5f, GameLayers.i.TriggerableLayer);
    }
    #endregion

    #region Encontro dos pokemon
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Terreno/Grama" && MoveInterroga == true)
        {
            Timer -= Time.deltaTime;

            if(Timer <= 0)
            {
                #region Chances dos pokemons
                switch (UnityEngine.Random.Range(1, 11))
                {
                    case 11:
                        
                    case 10:
                        
                    case 9:
                        
                    case 8:
                        
                    case 7:
                        
                    case 6:
                        Debug.Log("Batata Encontrado");
                        break;
                    case 5:
                        break;
                    case 4:
                        break;
                    case 3:
                        break;
                    case 2:
                        break;
                    case 1:
                        Debug.Log("Vassour Encontrado");
                        OnEcountered();
                        Timer = UnityEngine.Random.Range(TempoDoEncontro[0], TempoDoEncontro[1]);
                        

                        int PokemonRandomico = 0;
                        PokemonRandomico = UnityEngine.Random.Range(1, 3);
                        if(PokemonRandomico == 1)
                        {
                            Debug.Log("Achou Charmander");
                            OnEcountered();
                        }

                        if (PokemonRandomico == 2)
                        {
                            Debug.Log("Achou Nada");
                        }

                        if (PokemonRandomico == 3)
                        {
                            Debug.Log("Achou Sim");
                        }
                        Timer = UnityEngine.Random.Range(TempoDoEncontro[0], TempoDoEncontro[1]);
                        break;
                       
                }
                #endregion
            }
        }
    }
}
#endregion 