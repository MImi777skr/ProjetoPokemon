using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]

public class POKEMONGOLBASE : ScriptableObject
{
    
    [SerializeField] string nome;
    [TextArea] [SerializeField] string Description;
    [SerializeField] Sprite FrontSprite;
    [SerializeField] Sprite BackSprite;
    [SerializeField] Animator WorldAnimation;
    //Base Stats

    [SerializeField] int MaxHP;
    [SerializeField] int AttackSpeed;
    [SerializeField] int Attack;
    [SerializeField] int Defense;
    [SerializeField] int DefensePCC;
    [SerializeField] int Speed;
    [SerializeField] PokemongolType Tipo1;
    [SerializeField] PokemongolType Tipo2;
    [SerializeField] List<aprendeOsMove> AprendeOsMove;
    #region Get Variaveis
    public string Nome
    {
        get { return nome; }
    }

    public int maxHP
    {
        get { return MaxHP; }
    }

    public int attackSpeed
    {
        get { return AttackSpeed; }
    }

    public int attack
    {
        get { return Attack; }
    }

    public int defense
    {
        get { return Defense; }
    }

    public int defensePCC
    {
        get { return DefensePCC; }
    }

    public int speed
    {
        get { return Speed; }
    }

    public string description
    {
        get { return Description; }
    }

    public Sprite frontSprite
    {
        get { return FrontSprite; }
    }
    public Sprite backSprite
    {
        get { return BackSprite; }
    }
    public Animator worldAnimation
    {
        get { return WorldAnimation; }
    }
    public PokemongolType tipo1
    {
        get { return Tipo1; }
    }
    public PokemongolType tipo2
    {
        get { return Tipo2; }
    }
   
    public List<aprendeOsMove> AprendendoOsMove
    {
        get { return AprendeOsMove; }
    }


    #endregion
}
[System.Serializable]
public class aprendeOsMove
{

    [SerializeField] MovimentosBase MoveBase;
    [SerializeField] int level;

    public MovimentosBase moveBase
    {
        get { return MoveBase;}
    }
     public int Level
    {
        get { return level; }
    }

}
public enum PokemongolType
{
    None,
    Normal,
    Fire,
    Water,
    Eletric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psichic,
    Bug,
    Rock,
    Phantom,
    Dragon,
    Fairy
}

public class TypeChart
{
    static float[][] chart = {

                        //    NORM   FOGO   AGUA   ELET   GRAM   GELO   LUTA   VENE   CHAO   VOAD   PSIC   INSE   PEDR   FANT   DRAG   FAIRY
        /*NORM*/ new float[] { 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 0.5f , 0f   , 1f  ,  1f  },
        /*FOGO*/ new float[] { 1f   , 0.5f , 0.5f , 1f   , 2f   , 2f   , 1f   , 1f   , 1f   , 1f   , 1f   , 2f   , 0.5f , 1f   , 0.5f,  1f  }, 
        /*AGUA*/ new float[] { 1f   , 2f   , 0.5f , 1f   , 0.5f , 1f   , 1f   , 1f   , 2f   , 1f   , 1f   , 1f   , 2f   , 1f   , 0.5f,  1f  },
        /*ELET*/ new float[] { 1f   , 1f   , 2f   , 0.5f , 0.5f , 1f   , 1f   , 1f   , 0f   , 2f   , 1f   , 1f   , 1f   , 1f   , 0.5f,  1f  },
        /*GRAM*/ new float[] { 1f   , 0.5f , 2f   , 1f   , 0.5f , 1f   , 1f   , 0.5f , 2f   , 0.5f , 1f   , 0.5f , 2f   , 1f   , 0.5f,  1f  },
        /*GELO*/ new float[] { 1f   , 1f   , 0.5f , 1f   , 2f   , 0.5f , 1f   , 1f   , 2f   , 2f   , 1f   , 1f   , 1f   , 1f   , 2f  ,  1f  },
        /*LUTA*/ new float[] { 2f   , 1f   , 1f   , 1f   , 1f   , 2f   , 1f   , 0.5f , 1f   , 0.5f , 0.5f , 0.5f , 2f   , 0f   , 1f  , 0.5f },
        /*VENE*/ new float[] { 1f   , 1f   , 1f   , 1f   , 2f   , 1f   , 1f   , 0.5f , 0.5f , 1f   , 1f   , 2f   , 0.5f , 0.5f , 1f  ,  2f  },
        /*CHAO*/ new float[] { 1f   , 2f   , 1f   , 2f   , 0.5f , 1f   , 1f   , 2f   , 1f   , 0f   , 1f   , 0.5f , 2f   , 1f   , 1f  ,  1f  },
        /*VOAD*/ new float[] { 1f   , 1f   , 1f   , 0.5f , 2f   , 1f   , 2f   , 1f   , 1f   , 1f   , 1f   , 2f   , 0.5f , 1f   , 1f  ,  1f  },
        /*PSIC*/ new float[] { 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 2f   , 2f   , 1f   , 1f   , 0.5f , 1f   , 1f   , 1f   , 1f  ,  1f  },
        /*INSE*/ new float[] { 1f   , 0.5f , 1f   , 1f   , 2f   , 1f   , 0.5f , 2f   , 1f   , 0.5f , 2f   , 1f   , 1f   , 0.5f , 1f  ,  0.5f},
        /*PEDR*/ new float[] { 1f   , 2f   , 1f   , 1f   , 1f   , 2f   , 0.5f , 1f   , 0.5f , 2f   , 1f   , 2f   , 1f   , 1f   , 1f  ,  1f  },
        /*FANT*/ new float[] { 0f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 0f   , 1f   , 1f   , 1f   , 2f   , 1f  ,  1f  },
        /*DRAG*/ new float[] { 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 1f   , 2f  ,  0f  },
        /*Fair*/ new float[] { 1f   , 0.5f , 1f   , 1f   , 1f   , 1f   , 2f   , 0.5f , 1f   , 1f   , 1f   , 1f   , 0.5f , 0f   , 2f  ,  1f  },

    };
    public static float GetEfective(PokemongolType attacktype , PokemongolType defensetype)
    {
        if(attacktype == PokemongolType.None || defensetype == PokemongolType.None)
        {
            return 1;
        }

        int row = (int)attacktype - 1;
        int col = (int)defensetype - 1;

        return chart[row][col];
    }
}