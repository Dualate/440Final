using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    int player_score;
    PlayerHealth player;
    SpawnManager spawner;
    
    public Canvas endScreen;
    bool gameActive = false;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        gameActive = true;
        endScreen.gameObject.SetActive(false);

        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        spawner = GameObject.Find("Spawner").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.health < 1 && gameActive)
        {
            EndRound();
        }
    }

    public void UpdateScore(int score)
    {
        player_score += score;
    }



    void EndRound()
    {
        spawner.EndGame();
        endScreen.gameObject.SetActive(true);
        scoreText.text = "Game Over!\nScore: " + "\nPlay Again?";
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void EndGame()
    {
        EditorApplication.ExitPlaymode();
    }


    public void ResetRound()
    {
        endScreen.gameObject.SetActive(false);
        gameActive = true;
        player.Reset();
        spawner.Reset();
    }
}
