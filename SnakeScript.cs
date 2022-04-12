using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SnakeScript : MonoBehaviour
{
    public GameObject tailPrefab;
    public UIHandlingScript uihandlingScript;
    public AudioSource sound;
    public Text scorePoints;
    public Text speed;
    public float snakespeed = 0.09f;
    public Slider SnakeSlider;

    List<Transform> tail = new List<Transform>();
    Vector2 dir, a;
    bool ate = false;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector2.right;
        InvokeRepeating("Move", 0f, snakespeed);
        speed.text = "0.09";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector2.left;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector2.down;

        scorePoints.text = "Score: " + tail.Count.ToString() + " Points";
    }

    void Move()
    {
        this.transform.Translate(dir);
        Vector2 v = this.transform.position;
        if (ate)
        {
            sound.Play();
            //Load Prefab
            GameObject g = (GameObject)Instantiate(tailPrefab, a, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
            Debug.Log("Ate the Food");
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = a;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
        a = v;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("FoodPrefab"))
        {
            Debug.Log("Collided with food");
            ate = true;
            Destroy(collision.gameObject);
        }
        else if(collision.name.StartsWith("Border"))
        {
            CancelInvoke();
            Debug.Log("Collided with border");
            sound.Play();
            uihandlingScript.PrintScore(tail.Count);
        }
        else if (collision.name.StartsWith("TailPrefab"))
        {
            CancelInvoke();
            Debug.Log("Collided with tail");
            sound.Play();
            uihandlingScript.PrintScore(tail.Count);
        }
    }

    public void SnakeSpeedSlider()
    {
        CancelInvoke();
        InvokeRepeating("Move", 0, snakespeed * (float)SnakeSlider.value);
        speed.text = (snakespeed * (float)SnakeSlider.value).ToString();
    }
}

