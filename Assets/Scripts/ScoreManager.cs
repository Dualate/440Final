using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player_score;

    private void Update()
    {

    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        player_score += score;
    }
}
