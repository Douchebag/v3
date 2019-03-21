using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        // baetir vid score-id thegar zombie deyr
        text.text = "Score: " + score;
    }
}
