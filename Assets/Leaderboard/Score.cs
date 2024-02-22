using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Score
{
    // Start is called before the first frame update
   public string name;
   public int score;

   public Score(string name, int score){
    this.name = name;
    this.score = score;
   }
}
