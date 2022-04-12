using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFoodScript : MonoBehaviour
{
    public GameObject foodPrefab;
    [SerializeField] Transform borderTop;
    [SerializeField] Transform borderBottom;
    [SerializeField] Transform borderLeft;
    [SerializeField] Transform borderRight;
    public float speed = 7f;
    public Slider FoodSpeed;
    public Text foodSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, speed);
        foodSpeed.text = "7";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x+1, borderRight.position.x-1);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y+1, borderTop.position.y-1);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); // default rotation
    }

    public void FoodSpeedSlider()
    {
        CancelInvoke();
        InvokeRepeating("Spawn", 0, speed * (float)FoodSpeed.value);
        foodSpeed.text = (speed * (float)FoodSpeed.value).ToString();
    }
}
