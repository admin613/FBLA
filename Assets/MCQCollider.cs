using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class MCQCollider : MonoBehaviour
{

    public GameObject mcqui;
    public MCQ minigame;
    public Collider2D BattleCollider;
    public Collider2D playerCollider;
    public DialougeSystem dialouge = null;
    
    public string[] questions;
    private string[][] answers;
    public string[] answers1;
    public string[] answers2;
    public string[] answers3;
    public int[] correctAnswers;
    public string[] dialouges;

 
    void Update()
    {

        if (playerCollider.IsTouching(BattleCollider))
        {
            controls.canMove = false;
            BattleCollider.enabled = false;
            answers = new string[][]{answers1, answers2, answers3};
            minigame.setQuestions(questions, answers, correctAnswers);
            dialouge.OpenDialouge(dialouges, mcqui);

        }
    }
}
