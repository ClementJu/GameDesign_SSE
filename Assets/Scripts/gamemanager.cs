using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    private bool inMainMenu = true;
    private bool inLevel = false;
    private AudioSource currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        this.currentMusic = this.gameObject.transform.Find("BackGroundMusic/MainMenu").gameObject.GetComponent<AudioSource>();
        this.currentMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        if (!inLevel)
        {
            this.currentMusic.Stop();
        }
        if (name.Contains("intro"))
        {

        }
        else
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(name);
            this.currentMusic = this.gameObject.transform.Find("BackGroundMusic/Levels").gameObject.GetComponent<AudioSource>();
            this.currentMusic.Play();
            inLevel = true;
        }
    }
}
