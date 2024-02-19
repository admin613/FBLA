using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class MiniGameStart : MonoBehaviour
{
    public GameObject minigame;
    public Collider2D BattleCollider;
    public Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerCollider.IsTouching(BattleCollider))
        {
            minigame.SetActive(true);
            controls.canMove = false;
            BattleCollider.enabled = false;
        }
    }
}
