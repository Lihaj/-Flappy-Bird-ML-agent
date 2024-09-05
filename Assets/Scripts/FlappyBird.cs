using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    public Score scoreText;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            //flap
            rb.velocity=Vector2.up *speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Column")){
            print("ScoreUp");
            scoreText.ScoreUp();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")|| other.gameObject.CompareTag("Pipe")){
           
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


