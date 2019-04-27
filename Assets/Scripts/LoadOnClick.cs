﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public void newGame()
    {
        GameObject.Find("GameManager").GetComponent<gamemanager>().LoadScene("Scenes/1_level");
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}