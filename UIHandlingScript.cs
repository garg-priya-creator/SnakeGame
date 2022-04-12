using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandlingScript : MonoBehaviour
{
    public Text myText;
    
    public void PrintScore(int score)
    {
        gameObject.SetActive(true);
        myText.text = score.ToString() + " Points";
    }

    public void Reset()
    {
        SceneManager.LoadScene("SnakeGame");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
