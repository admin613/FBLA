using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN,ENEMYTURN,WON,LOST,STOP}
public enum GameState { STATE1, STATE2, STATE3, STATE4}
public class BattleSystem : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject Unit;
    public GameObject Canvas;
    public RectTransform Enemytransform;
    public BattleState state;
    public GameState gstate;
  

    public string unitName;
    public int damage;
    public int maxHP;
    public Slider enemySlider;
    public int currentHP;

    public int playerHP;
    public int Playerdamage;
    public int PlayermaxHP;
    public Slider PlayerSlider;

    public string EnemyName;
    


    public TextMeshProUGUI description;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 20;
        Playerdamage = 1;
        PlayermaxHP = 20;
        PlayerSlider.maxValue = PlayermaxHP;
        PlayerSlider.value = PlayermaxHP;

        gstate = GameState.STATE1;
    }
    public void BattleStart()
    {
        if(state != BattleState.START)
        {
            state = BattleState.START;
            StartCoroutine(SetupBattle());
        }
        
    }

    IEnumerator SetupBattle()
    {
        Canvas.SetActive(true);
        if(gstate == GameState.STATE1)
        {
            unitName = EnemyName;
            damage = 1;
            maxHP = 5;
            currentHP = 5;
        }
        enemySlider.maxValue = maxHP;
        enemySlider.value = maxHP;
        description.text = unitName + " Approaches!";
        state = BattleState.PLAYERTURN;
        yield return new WaitForSeconds(1f);
        
        description.text = "Choose a attack:";



    }

        
    public void OnattackButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());

    }
    IEnumerator PlayerAttack()
    {

        currentHP -= Playerdamage;
        enemySlider.value = (currentHP);
        state = BattleState.ENEMYTURN;
        description.text = "You used FBLA CONCPET!";
        yield return new WaitForSeconds(1f);
        if (currentHP <= 0)
        {
            state = BattleState.WON;
            Canvas.SetActive(false);
            controls.canMove = true;
            yield break;
        }

       

        yield return new WaitForSeconds(0.5f);
        description.text = unitName + " attacked with \"procrastination\"";
        playerHP -= damage;
        PlayerSlider.value = playerHP;

        yield return new WaitForSeconds(1f);
        if(playerHP <= 0)
        {
            state = BattleState.LOST;
            Canvas.SetActive(false);
            yield break;
        }

        state = BattleState.PLAYERTURN;
        description.text = "Choose a action:";

    }

}
