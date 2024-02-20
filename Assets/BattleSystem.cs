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

    public GameObject HealthUI;
    public GameObject AttackButton;
    public GameObject moveSelector;
    public GameObject moveDescriptionUI;
    public GameObject DescriptionUI;
   
    private int frozen = 0;
    public string unitName;
    public int damage;
    public int maxHP;
    public Slider enemySlider;
    public int currentHP;
    public int playerHP;
    public int Playerdamage;
    public int PlayermaxHP;
    public Slider PlayerSlider;
    public string[] movelist = { "Sustainability Strike"," Finance Freeze","Cash Flow Crumble","Business Longevity"};
    
    public int[] attackMultiplier = { 1, 0, 0 ,0 };
    public string[] moveDescriptions = {"Deals damage", "freezes enemy for" + attackMultiplier[1] +  "turn", "increases your attack by 1", "heals you by 10 hp"};

    public string EnemyName;
    


    public TextMeshProUGUI description;
    public TextMeshProUGUI moveDescription;
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
    public void OnMove1ButtonClicked(int num)
    {
        StartCoroutine(PlayerAttack(num));
    }
    public void OnHover(int num)
    {
        moveDescription.text = moveDescriptions[num];
    }
    public void OnattackButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;
        toggleElements(false);
    }
    public void toggleElements(bool enabled)
    {
        HealthUI.SetActive(enabled);
        AttackButton.SetActive(enabled);
        DescriptionUI.SetActive(enabled);
        moveSelector.SetActive(!enabled);
        moveDescriptionUI.SetActive(!enabled);
    }


    
    IEnumerator PlayerAttack(int attacktype)
    {
        toggleElements(true);
        description.text = "You used " + movelist[attacktype] + "!";
        if (attacktype == 0)
        {
            currentHP -= Playerdamage * attackMultiplier[0];
            enemySlider.value = (currentHP);
            state = BattleState.ENEMYTURN;
            yield return new WaitForSeconds(1f);
            if (currentHP <= 0)
            {
                state = BattleState.WON;
                Canvas.SetActive(false);
                controls.canMove = true;
                yield break;
            }
        }
        if(attacktype == 1 && attackMultiplier[1] > 0 )
        {
            frozen = 1 - attackMultiplier[1];
        }
        if(attacktype == 2 && attackMultiplier[2] > 0)
        {
            Playerdamage += attackMultiplier[2];
        }
        if(attacktype == 3 attackMultiplier[3] > 0)
        {
            if (playerHP + 10 * attackMultiplier[3] > PlayermaxHP)
                playerHP = PlayermaxHP;
            else
                playerHP += 10 * attackMultiplier[3];
        }

        if (frozen == 2)
        {
            yield return new WaitForSeconds(0.5f);
            description.text = unitName + " attacked with \"procrastination\"";
            playerHP -= damage;
            PlayerSlider.value = playerHP;

            yield return new WaitForSeconds(1f);
            if (playerHP <= 0)
            {
                state = BattleState.LOST;
                Canvas.SetActive(false);
                yield break;
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            description.text = unitName + " is frozen!";
            frozen++;
        }

        
        state = BattleState.PLAYERTURN;
       
        description.text = "Choose a action:";

    }

}
