using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class NewBehaviourScript : MonoBehaviour
{
    public BattleSystem battle;
    public Collider2D BattleCollider;
    public Collider2D playerCollider;
    public DialougeSystem dialouge;
    public string[] dialouges = { "hello", "hi", "asdfasjdflas;dfkasj" };

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
            dialouge.OpenDialouge(dialouges, battle);
           
        }
    }
}
