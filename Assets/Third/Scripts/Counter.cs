using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text score;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
   private void Update()
    {
        score.text = Score.ToString();
    }


   public void AddScore()
   {
        Score += 1;
   }
}
