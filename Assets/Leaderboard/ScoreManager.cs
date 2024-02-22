using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private ScoreData sd;
    void Awake()
    {
        sd = new ScoreData();
    }

    // Update is called once per frame
   public IEnumerable<ScoreManager> GetHighScores(){
    return sd.scores.OrderByDescending(x => x.score);
   }

   public void AddScore(Score score){
    sd.scores.Add(score);
   }
}
