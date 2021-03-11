using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class BallScript : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text MessageText;
    void Start(){
        scoreText = "Score: ";

    }
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision);
        score++;
        scoreText = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D trigger){
        Debug.Log("Game Over!");
        MessageText = "Game Over!";
    }
}
