using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController gameControllerInstance;


    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Vector2 direction = Vector2.down;
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float scoreInterval;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text starText;

    private int score;
    private int stars;
    private int health = 1;

    private bool gameRunning = false;

    void Awake(){
        gameControllerInstance = this;
        StartGame();
    }

    private void StartGame() {
        gameRunning = true;
        gameOverPanel.SetActive(false);

        SetScore(0);
        SetStars(0);

        StartCoroutine(ScoreLoop());
    }

    private IEnumerator ScoreLoop() {
        // Could alternatly use time.deltaTime instead
        while(IsRunning()) {
            yield return new WaitForSeconds(scoreInterval);
            IncrementScore(1);
        }
    }


    public Vector2 GetDirection() {
        return direction;
    }

    public float GetSpeed() {
        return speed;
    }

    private void SetScore(int value) {
        score = value;
        scoreText.text = score.ToString();
    }

    public void IncrementScore(int value) {
        SetScore(score + value);
    }

    private void SetStars(int value) {
        stars = value;
        starText.text = stars.ToString();
    }

    public void IncrementStars(int value) {
        SetStars(stars + value);
    }

    private void SetHealth(int value) {
        health = value;
        if(health <= 0) {
            EndGame();
        }
    }

    public void DecrementHealth(int value) {
        SetHealth(health - value);
    }

    public bool IsRunning() {
        return gameRunning;
    }

    private void EndGame() {
        Debug.Log("Game Over!");
        gameRunning = false;
        gameOverPanel.SetActive(true);
        Destroy(player);
    }

    public void Restart() {
        Debug.Log("Restarting Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
