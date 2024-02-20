using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Collider2D NPCCollider;
    public Collider2D playerCollider;
    public DialougeSystem dialouge;
    public GameObject g = null;
    
    public string[] dialouges = { "Lore lore Lore lore Lore lore Lore lore Lore lore Lore lore", "hi", "asdfasjdflas;dfkasj"};


    // Update is called once per frame
    void Update()
    {
        if (playerCollider.IsTouching(NPCCollider))
        {
            controls.canMove = false;
            NPCCollider.enabled = false;
            dialouge.OpenDialouge(dialouges,g);

        }
    }
}
