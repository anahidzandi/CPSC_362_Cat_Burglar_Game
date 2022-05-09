using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text score;
    public PlayerInventory pI;
    public timer time;

    
    void Update()
    {
        float finalScore = time.timeRemaining + (pI.fish * 100);
        score.text = finalScore.ToString("F0");
    }
}
