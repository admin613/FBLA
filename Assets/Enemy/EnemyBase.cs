using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create new enemy")]
public class EnemyBase : ScriptableObject
{
    public string _name;
    public string description;
    public Sprite enemySprite;
    public EnemyType type;
    public int maxHP;
    public int attack;
    public int defense;
    public int speed;




}
public enum EnemyType
{
    None,
    Staff,
    Manager,
    GeneralManager,
    VicePresident,
    President,
    CEO,

}
