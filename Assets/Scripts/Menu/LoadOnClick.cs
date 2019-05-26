using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public void newGame()
    {
        GameObject.Find("GameManager").GetComponent<gamemanager>().LoadScene("Scenes/intro");
    }

    public void playGame()
    {
        GameObject.Find("GameManager").GetComponent<gamemanager>().LoadScene("Scenes/1_level");
    }

    public void history()
    {
        GameObject.Find("GameManager").GetComponent<gamemanager>().LoadScene("Scenes/history");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        GameObject.Find("GameManager").GetComponent<gamemanager>().LoadScene("Scenes/mainMenu");
    }

}