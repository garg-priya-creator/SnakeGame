using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public Text score;
    public void Setup(int s)
    {
        gameObject.SetActive(true);
        score.text = s.ToString() + " Points";
    }

    public void ResetButton()
    {
        SceneManager.LoadScene("ArkanoidGame");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
