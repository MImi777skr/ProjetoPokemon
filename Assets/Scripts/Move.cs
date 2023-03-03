using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public MovimentosBase moveBase { get; set; }
    public int Powerpoint { get; set; }

    public Move(MovimentosBase mBase)
    {
        moveBase = mBase;
        Powerpoint = mBase.powerPoint;
    }
}
