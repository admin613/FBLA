
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MCQ : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI timeLeftText;
    public string addString;
    public int multiplierIndex;


    public float timeLimit = 20f; // Time limit per question
    private float timeLeft = 20f;
    private bool isAnswered = false;

    // Sample questions and answers
    private string[] questions = { "Who is Princewill Osuji's crush?", "What is 2 + 2?", "IIIIIIIIIIIIIIII/''afsjasdfasdfkasj;dflkajs;saflkaksldfjaklsdfj" };
    private string[][] answers = {
        new string[] { "Dyuti", "Ellie", "Selena","Anvil" },
        new string[] { "3", "4", "5","6" },
        new string[] { "fuckyou", "fukkcy", "fasjdfl;k","FUCk YOUasldfjas;dkfjaasdfasdflkjjl;aasdlfkj" }
    };
    private int[] correctAnswers = { 2, 1, 0 }; // Indices of correct answers

    private int currentQuestionIndex = 0;
    private int playerScore = 0;

    void Start()
    {
        ShowQuestion(currentQuestionIndex);
    }

    void Update()
    {
        if (!isAnswered)
        {
            Debug.Log(timeLeft);
            timeLeft -= Time.deltaTime;
            
            timeLeftText.text = "" + Mathf.Round(timeLeft);

            if (timeLeft <= 0)
            {
                StartCoroutine(TransitionToNextQuestion());
            }
        }
    }

    public void AnswerButtonClicked(int answerIndex)
    {
        if (!isAnswered)
        {
            isAnswered = true;
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i != correctAnswers[currentQuestionIndex])
                {
                    answerButtons[i].GetComponent<Image>().color = Color.red;
                }
                else
                {
                    answerButtons[i].GetComponent<Image>().color = Color.green;
                }
            }
            if (answerIndex == correctAnswers[currentQuestionIndex])
            {
                playerScore++;
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }
  

    void ShowQuestion(int index)
    {
        questionText.text = questions[index];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[index][i];
            answerButtons[i].GetComponent<Image>().color = Color.white;
        }
        timeLeft = timeLimit;
        isAnswered = false;
    }

    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(2f); 
        NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            
            questionText.text = "Quiz Finished!";
            StartCoroutine(Waiter());
            if(playerScore >= questions.Length - 1)
            {
                controls.attackMultiplier[multiplierIndex] = 1;
                controls.movelist[multiplierIndex] = addString; 
                controls.investors += 100;
            }
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].gameObject.SetActive(false);
            }
            
        }
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        controls.canMove = true;
    }
}