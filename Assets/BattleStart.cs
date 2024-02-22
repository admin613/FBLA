using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Canvas;
    public BattleSystem battle;
    public Collider2D BattleCollider;
    public Collider2D playerCollider;
    public DialougeSystem dialouge;
    public Sprite enemySprite;
    public string[] dialouges;

    public int hp;
    public int damadge;

    public string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerCollider.IsTouching(BattleCollider))
        {
            controls.canMove = false;
            BattleCollider.enabled = false;
            if(dialouges[0] != ""){
            dialouge.OpenDialouge(dialouges, battle, name, damadge, hp, enemySprite);
            }
            battle.BattleStart(name, damadge, hp, enemySprite);
            
        }
    }
}
