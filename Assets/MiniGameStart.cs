using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class MiniGameStart : MonoBehaviour
{
    public GameObject minigame;
    public Collider2D BattleCollider;
    public Collider2D playerCollider;
    public DialougeSystem dialouge = null;
    public string[] dialouges;
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
            dialouge.OpenDialouge(dialouges, minigame);
            }
            
            
        }
    }
}
