using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts)
            health = numOfHearts;

        for(int i = 0; i < heartImages.Length; i++)
        {
            if(i < health)
                heartImages[i].sprite = fullHeart;
            else
                heartImages[i].sprite = emptyHeart;

            if(i < numOfHearts)
                heartImages[i].enabled = true;
            else 
                heartImages[i].enabled = false;
        }

        if(health == 0)
        {
            //game over
            Debug.Log("The player has died.");
        } 
    }

    public void TakeDamage() {
        health -= 1;
    }
}