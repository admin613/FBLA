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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero)
        {   if (movement.x < 0)
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