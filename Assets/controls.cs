using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Transform player;
    public float movespeed = 5f;
    Vector2 movement;
    public Animator animator;
    public BattleSystem battle;
    public GameObject bargame;
    public Collider2D bargameCollider;
    public Collider2D mcqgameCollider;
    public Collider2D playerCollider;
    public GameObject trig;
    public GameObject mcq;
    public static bool canMove = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(playerCollider.IsTouching(bargameCollider))
        {
            bargame.SetActive(true);
            canMove = false;
            bargameCollider.enabled = false;
        }
        if (playerCollider.IsTouching(mcqgameCollider))
        {
            mcq.SetActive(true);
            canMove = false;
            mcqgameCollider.enabled = false;
        }
        if (movement != Vector2.zero && canMove)
        {
            float rng = Random.Range(0f, 100f);
            if(rng < 0.03f)
            {
                battle.BattleStart();
                canMove = false;
            }

            if (movement.x < 0)
                player.localScale = new Vector3(-1, 1, 1);
            else
                player.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * movespeed * Time.fixedDeltaTime);
    }
}
