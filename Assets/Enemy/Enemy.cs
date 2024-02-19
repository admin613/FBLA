using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    EnemyBase _base;
    int level;
    public Enemy(EnemyBase ebase, int pLevel)
    {
        _base = ebase;
        pLevel = level;
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((_base.attack * level) / 100f) + 5;}
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.maxHP * level) / 100f) + 10; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((_base.defense * level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((_base.speed * level) / 100f) + 5; }
    }
}
