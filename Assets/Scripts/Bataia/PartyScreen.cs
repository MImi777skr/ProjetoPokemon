using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyScreen : MonoBehaviour
{
    [SerializeField] Text TextoDaMsg;
    [SerializeField] UIdaParty[] PokemonSlots;
    List<Pokemongol> pokemongols;

    public void Init()
    {
        PokemonSlots = GetComponentsInChildren<UIdaParty>();
    }
    public void SetPartyData(List<Pokemongol> pokemongols)
    {
        this.pokemongols = pokemongols;
        for( int a = 0; a < PokemonSlots.Length; a++)
        {
            if (a < pokemongols.Count)
            {
                PokemonSlots[a].SetData(pokemongols[a]);
            }
            else
            {
                PokemonSlots[a].gameObject.SetActive(false);
            }
        }
       
    }
    public void UpdateSelecaoDePokemon(int PokemonSelecionado)
    {
        for(int a = 0; a < pokemongols.Count; a++)
        {
            if( a == PokemonSelecionado)
            {
                PokemonSlots[a].SetSelected(true);
            }
            else
            {
                PokemonSlots[a].SetSelected(false);
            }
        }
    }
    public void SetMensagem(string mensagem)
    {
        TextoDaMsg.text = mensagem;
    }
}
