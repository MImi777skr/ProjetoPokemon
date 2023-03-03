using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    [SerializeField] List<Pokemongol> WildPokemons;

    public Pokemongol GetRandomWildPokemon()
    {
        var wildPokemon = WildPokemons[Random.Range(0,WildPokemons.Count)];
        wildPokemon.Inicializacao();
        return wildPokemon;
    }
}
