using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pokemongol
{
    [SerializeField] POKEMONGOLBASE _base;
    [SerializeField] int level;
    public POKEMONGOLBASE Base { get { return _base; } }
    public int Level { get { return level; }  }
   
    public List<Move> MoveList { get; set; }
    public int HP { get; set; }
    public void Inicializacao()
    {
      
        HP = MaxHP;

        //Movimentos PICA
        MoveList = new List<Move>();
        foreach(var move in Base.AprendendoOsMove)
        {
            if (move.Level <= level)
            {
                MoveList.Add(new Move(move.moveBase));
            }
            if (MoveList.Count >= 4)
                break;
        }
    }

    public int attack
    {
        get { return Mathf.FloorToInt((Base.attack * level)/ 23.9f) +5; }
    }
    public int defense
    {
        get { return Mathf.FloorToInt((Base.defense * level) / 23.9f) + 5; }
    }
    public int attackSpeed
    {
        get { return Mathf.FloorToInt((Base.attackSpeed * level) / 23.9f) + 5; }
    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((Base.maxHP * level) / 23.9f) + 5; }
    }

    public int DefensePCC
    {
        get { return Mathf.FloorToInt((Base.defensePCC * level) / 23.9f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((Base.speed * level) / 23.9f) + 5; }
    }

    public DetalheDano DanoTomado(Move move, Pokemongol atacante)
    {
        float crit = 1f;
        if (Random.value * 100f <= 5f)
        {
            crit = 2f;
            Debug.Log("CRITEI PORRA");
        }

        float TypeDamage = TypeChart.GetEfective(move.moveBase.Type, this.Base.tipo1) * TypeChart.GetEfective(move.moveBase.Type, this.Base.tipo2);
        var DetalheDano = new DetalheDano() { Fainted = false, Crit = crit, Efetividade = TypeDamage };
        float attack = (move.moveBase.IsPCC) ? atacante.attackSpeed : atacante.attack;
        float Defesa = (move.moveBase.IsPCC) ? DefensePCC : defense;
        float modificador = Random.Range( 0.85f, 1f) * TypeDamage;
        float a = (2 * atacante.level * crit)/5f + 2;
        float d = (a * move.moveBase.power * (attack / Defesa))/50f +2;
        int damage = Mathf.FloorToInt(d * modificador);

        HP -= damage;
        if( HP <= 0)
        {
            HP = 0;
            DetalheDano.Fainted = true;
        }
         return DetalheDano;
    }
    public Move GetRandomMove()
    {
        int r = Random.Range(0, MoveList.Count);
        return MoveList[r];
    }
}
public class DetalheDano
{
    public bool Fainted { get; set; }
    public float Crit { get; set; }
    public float Efetividade { get; set; }


}
