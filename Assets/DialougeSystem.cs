using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialougeSystem : MonoBehaviour
{   
    public TextMeshProUGUI dialougebox;
    public GameObject game;
    public MCQ mcq;
    public BattleSystem battle;
    public GameObject mcqui;
    public Sprite c;
    public string[] dialouge;

    int i = 0;
    bool isBattle = false;
    bool isMcq = false;
    public void OpenDialouge(string[] dialouge){
        isBattle = false;
        isMcq = false;
        gameObject.SetActive(true);
        this.dialouge = dialouge;
        dialougebox.text = dialouge[0];
    }
    public void OpenDialouge(string[] dialouge, GameObject game)
    {
        if (dialouge.Length < 1)
            game.SetActive(true);
        else
        {
            isBattle = false;
            isMcq = false;
            gameObject.SetActive(true);
            this.dialouge = dialouge;
            dialougebox.text = dialouge[0];
            this.game = game;
        }
     
    }

    public void OpenDialouge(string[] dialouge, BattleSystem game, string name, int damadge, int hp, Sprite c)
    {
        if (dialouge.Length < 1)
            game.BattleStart(name, damadge, hp, c);
        else
        {
            isBattle = true;
            isMcq = false;
            gameObject.SetActive(true);
            this.dialouge = dialouge;
            dialougebox.text = dialouge[0];
            battle = game;
        }
        
    }

    public void OnButtonclick()
    {
        i++;
        if (i >= dialouge.Length)
        {

            if (!isBattle && game != null)
            {
                game.SetActive(true);
            }
            else if (isBattle)
            {
                battle.BattleStart("Unethical Employee", 5, 5, c);
            }
            else
                controls.canMove = true;

            gameObject.SetActive(false);
            i = 0;
        }
        else
        {
            dialougebox.text = dialouge[i];
        }
            
            
    }
}
