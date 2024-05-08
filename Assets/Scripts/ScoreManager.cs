using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int player_score;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + player_score;
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        player_score += score;
    }
}
