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

    public void SetData(Pokemongol pokemongol)
    {
        pokemon = pokemongol;

        Nametxt.text = pokemongol.Base.name;
        Leveltxt.text = $"Lvl {pokemongol.Level}";
        HPbar.SetHp((float)pokemongol.HP / (float)pokemongol.MaxHP);
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
