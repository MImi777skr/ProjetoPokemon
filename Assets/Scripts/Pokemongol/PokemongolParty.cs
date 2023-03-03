using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PokemongolParty : MonoBehaviour
{
    [SerializeField] List<Pokemongol> pokemongols;

    private void Start()
    {
       foreach(var ListPokemons in pokemongols)
        {
            ListPokemons.Inicializacao();
        }
    }
    public Pokemongol GetNextPokemon()
    {
        return pokemongols.Where(x => x.HP > 0).FirstOrDefault();
    }
}
