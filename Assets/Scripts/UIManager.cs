using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _score = 0;
    public Text scoreText;

    public void updateScore(int sum)
    {
        _score += sum;
        scoreText.text = "Score: " + _score;
    }
}
