using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public float speed = 100.0f;
    public int score = 0;
    public Text scorePrint;
    public GameOverScreenScript gameover;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        scorePrint.text = "Score: " + score + " Points";
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else if (col.gameObject.name.EndsWith("Block"))
        {
            score++;
            Destroy(col.gameObject);
            scorePrint.text = "Score: " + score + " Points";
        }
    }

    private void OnBecameInvisible()
    {
        gameover.Setup(score);
    }
}
