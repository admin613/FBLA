using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public static Transform player;
    public float movespeed = 5f;
    Vector2 movement;
    public Animator animator;
    public static bool canMove = true;
    public static string[] movelist = { "Sustainability Strike", "-", "-", "-"};
    public static string[] moveDescriptions = {"Deals damage", "", "", ""};
    public static int[] attackMultiplier = { 1, 0, 0 ,0 };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero && canMove)  //movement
        {
           
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
        if(canMove)
            rb.MovePosition(rb.position + movement.normalized * movespeed * Time.fixedDeltaTime);
    }
}
