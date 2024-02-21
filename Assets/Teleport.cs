using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Collider2D tpCollider;
    public Collider2D playerCollider;
    public DialougeSystem dialouge;
    
    public int[] cords;
    public controls wow;
    public string[] dialouges;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(tpCollider.IsTouching(playerCollider)){
        tpCollider.enabled = false;
        wow.player.position = new Vector2(cords[0], cords[1]);
        if(dialouges[0] != ""){
            dialouge.OpenDialouge(dialouges);
       }
       } 
       
    }
}
