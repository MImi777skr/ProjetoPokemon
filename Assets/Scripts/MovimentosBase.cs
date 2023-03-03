using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movimentos", menuName = "Movimentos/Create new move")]

public class MovimentosBase : ScriptableObject
{
    [SerializeField] string Name;
    [TextArea] [SerializeField] string Description;
    [SerializeField] PokemongolType type;
    [SerializeField] int Power;
    [SerializeField] int Accuracy;
    [SerializeField] int PowerPoint;

    public string name
    {
        get { return Name; }
    }

    public string description
    {
        get { return Description; }
    }

    public PokemongolType Type
    {
        get { return type; }
    }

    public int power
    {
        get { return Power; }
    }

    public int powerPoint
    {
        get { return PowerPoint; }
    }

    public int accuracy
    {
        get { return Accuracy; }
    }
    public bool IsPCC
    {
        get
        {
            if (type == PokemongolType.Fairy || type == PokemongolType.Dragon || type == PokemongolType.Eletric || type == PokemongolType.Fire || type == PokemongolType.Grass || type == PokemongolType.Ice || type == PokemongolType.Psichic || type == PokemongolType.Phantom || type == PokemongolType.Water)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
