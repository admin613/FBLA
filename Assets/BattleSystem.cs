using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN,ENEMYTURN,WON,LOST,STOP}
public enum GameState { STATE1, STATE2, STATE3, STATE4}
public class BattleSystem : MonoBehaviour
{


    public GameObject Canvas;
    public BattleState state;
    public GameState gstate;

    public GameObject HealthUI;
    public GameObject AttackButton;
    public GameObject moveSelector;
    public GameObject moveDescriptionUI;
    public GameObject DescriptionUI;
   
    private int frozen = 2;
    public string unitName;
    public int damage;
    public int maxHP;
    public Slider enemySlider;
    public int currentHP;
    public int playerHP;
    public int Playerdamage;
    public int PlayermaxHP;
    public GameObject[] buttons;
    public Slider PlayerSlider;
    
    //," Finance Freeze","Cash Flow Crumble","Business Longevity"};
    
    
    

    
    


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
        frozen = 2;
        gstate = GameState.STATE1;
    }
    public void BattleStart(string name, int damage, int hp, GameObject c)
    {
        Canvas = c;
        if(state != BattleState.START)
        {
            state = BattleState.START;
            StartCoroutine(SetupBattle(name, damage, hp));
        }
        
    }

    IEnumerator SetupBattle(string name, int idamadge, int ihp)
    {
        Canvas.SetActive(true);
        if(gstate == GameState.STATE1)
        {
            unitName = name;
            damage = idamadge;
            maxHP = ihp;
            currentHP = ihp;
        }
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = controls.movelist[i];
            if (controls.movelist[i].Equals("-"))
            {
                buttons[i].GetComponent<Button>().enabled = false;
            }
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
        moveDescription.text = controls.moveDescriptions[num];
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
        description.text = "You used " + controls.movelist[attacktype] + "!";
        if (attacktype == 0)
        {
            currentHP -= (int)(Playerdamage * controls.attackMultiplier[0]);
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
        if(attacktype == 1 && controls.attackMultiplier[1] > 0 )
        {
            frozen = 1 - controls.attackMultiplier[1];
        }
        if(attacktype == 2 && controls.attackMultiplier[2] > 0)
        {
            Playerdamage += (int)controls.attackMultiplier[2];
        }
        if(attacktype == 3 && controls.attackMultiplier[3] > 0)
        {
            if (playerHP + 10 * controls.attackMultiplier[3] > PlayermaxHP)
                playerHP = PlayermaxHP;
            else
                playerHP += 10 * controls.attackMultiplier[3];
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
