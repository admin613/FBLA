using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy",menuName = "Enemy/Create new move")]
public class MoveBase : ScriptableObject
{
    public string name;
    public string description;
    public int power;
    public int accuracy;
    public int pp;

}
