using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public  Transform player;
    public float movespeed = 5f;
    public static int investors;
    Vector2 movement;
    public Animator animator;
    public static bool canMove = true;
    public static string[] movelist = { "Sustainability Strike", "-", "-", "-"};
    public static string[] moveDescriptions = {"Deals damage", "", "", ""};
    public static int[] attackMultiplier = { 1, 0, 0 ,0 };
    public bool second;
    void Start()
    {
        investors = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!second)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            if(Input.GetKey(KeyCode.L))
                movement.x = 1;
            else
                movement.x = 0;
            if (Input.GetKey(KeyCode.J))
                movement.x = -1;
            else
                movement.x = 0;
            if (Input.GetKey(KeyCode.I))
                movement.y = 1;
            else
                movement.y = 0;
            if (Input.GetKey(KeyCode.K))
                movement.y = -1;
            else
                movement.y = 0;

        }
        

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
