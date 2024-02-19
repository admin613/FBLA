using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
   MoveBase _base;
    public int PP;
    public Move(MoveBase eBase, int ppp)
    {
        _base = eBase;
        PP = ppp;
    }
}
