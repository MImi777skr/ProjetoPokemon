using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIdaParty : MonoBehaviour
{
    [SerializeField] Text Nametxt;
    [SerializeField] Text Leveltxt;
    [SerializeField] BarraDeHp HPbar;
    [SerializeField] Color CorNormal;
    [SerializeField] Color CorSelecionada;

    Pokemongol pokemon;

    public void SetData(Pokemongol _pokemongol)
    {
        pokemon = _pokemongol;

        Nametxt.text = _pokemongol.Base.Nome;
        Leveltxt.text = $"Lvl {_pokemongol.Level}";
        HPbar.SetHp((float)_pokemongol.HP / (float)_pokemongol.MaxHP);
    }

    public void SetSelected(bool Selecionado)
    {
        if (Selecionado)
        {
            Nametxt.color = CorSelecionada;
        }
        else
        {
            Nametxt.color = CorNormal;
        }

    }
    
}
