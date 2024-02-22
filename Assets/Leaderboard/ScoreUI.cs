using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start(){
        scoreManager.AddScore(new Score("Chika", 6));
        scoreManager.AddScore(new Score("Osuji", 66));
        var scores = new ScoreManager.GetHighScores().ToArray();
        for(int i = 0; i< scores.Length; i++){
           var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
           row.rank.text = (i + 1).ToString();
           row.name.text = scores[i].name;
           row.score.text = scores[i].score.ToString();
        }
    }
    // Start is called before the first frame update
    
}
