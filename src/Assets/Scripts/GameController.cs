using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController gameControllerInstance;


    [SerializeField]
    private Vector2 direction = Vector2.down;
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text starText;

    private int score;
    private int stars;
    private int health = 1;

    void Awake(){
        gameControllerInstance = this;
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
}
