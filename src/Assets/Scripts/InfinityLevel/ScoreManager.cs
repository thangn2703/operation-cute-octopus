using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public Text starDisplay;

    public Player player;

    private void Update()
    {
        scoreDisplay.text = "Meter: " + score.ToString();
        starDisplay.text = "Stars: " + player.starCollection.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score++;
            Debug.Log(score);
        }
    }
}
