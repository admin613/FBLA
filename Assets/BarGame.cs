using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarGame : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform TOP;
    public GameObject canvas;
    public RectTransform BOTTOM;
    public RectTransform MID;
    public RectTransform TOPBAR;
    public RectTransform BOTTOMBAR;
    public float oscillationSpeed = 1f;
    public float accelerationRate = 0.5f;
    bool clicked = false;

    
    public TextMeshProUGUI scoreText;
    public GameObject great;
    public GameObject bad;
    private bool movingUp = true;
    private float currentSpeed;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = oscillationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (movingUp)
            bar.Translate(Vector3.up * currentSpeed * Time.deltaTime);
        else
            bar.Translate(Vector3.down * currentSpeed * Time.deltaTime);

        scoreText.text = "Score: " + score;

        if (Input.GetMouseButtonDown(0) && !clicked)
        {


            StartCoroutine(doSomething());

                
            
        }

        if (TOPBAR.position.y  >= TOP.position.y)
        {

            movingUp = false;
        }

        if (BOTTOMBAR.position.y<= BOTTOM.position.y)
        {
            movingUp = true;
        }
    }
    IEnumerator doSomething()
    {
        clicked = true;
        float realcurrent = currentSpeed;
        currentSpeed = 0;
        int points = (int)(10 * TOPBAR.position.y);
        score += points;
        // for both win and lose we have to add win/loss screens same for other games
        if(score < 0){ //quit out when lose, losing condition
         bar.position = new Vector3(bar.position.x, MID.position.y, bar.position.z);
            movingUp = false;
            clicked = false;
            oscillationSpeed = 10;
            score = 0; 
            canvas.SetActive(false);
            controls.canMove = true;   
        }
        if(score >= 300)
        { 
            //todo: add reward , points and attack upgrade etc.
            controls.attackMultiplier[2] = 1;
            controls.movelist[2] = "Confidence Cascade"; 
            bar.position = new Vector3(bar.position.x, MID.position.y, bar.position.z);
            movingUp = false;
            clicked = false;
            oscillationSpeed = 10;
            score = 0; 
            canvas.SetActive(false);
            controls.canMove = true;
        }
        if (points > 0)
        {
            great.SetActive(true);

        }
        else
            bad.SetActive(true);
        Debug.Log("Points gained: " + points);
        yield return new WaitForSeconds(0.5f);
        bar.position = new Vector3(bar.position.x, MID.position.y, bar.position.z);
        movingUp = false;
        clicked = false;
        yield return new WaitForSeconds(0.5f);

        great.SetActive(false);
        bad.SetActive(false);

        currentSpeed = realcurrent;
        if(points>0)
            currentSpeed += accelerationRate;
        
    }
}
