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

    public AudioClip bgMusic;
    public AudioClip pickupSound;
    AudioSource source;

    void Start()
    {
        gameActive = true;
        endScreen.gameObject.SetActive(false);
        source = GetComponent<AudioSource>();
        source.PlayOneShot(bgMusic);
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

    public void Pickup()
    {
        source.PlayOneShot(pickupSound);
    }

    void EndRound()
    {
        spawner.EndGame();
        endScreen.gameObject.SetActive(true);
        scoreText.text = "Game Over!\nScore: " + player_score + "\nPlay Again?";
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }


    public void ResetRound()
    {
        player_score = 0;
        endScreen.gameObject.SetActive(false);
        gameActive = true;
        player.Reset();
        spawner.Reset();
    }
}
