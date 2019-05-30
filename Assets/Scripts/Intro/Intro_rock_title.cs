using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_rock_title : MonoBehaviour
{
    public Camera oldCam;
    public Camera newCam;
    public float title_trigger = 0;
    private bool havePlay = false;
    public float next_scene = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldCam.gameObject.SetActive(false);
        newCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(title_trigger >= 1 && havePlay == false)
        {
            GetComponent<AudioSource>().Play();
            havePlay = true;
        }
        if(next_scene == 1)
        {
            GameObject.Find("IntroSequence").GetComponent<Sequence>().NextSequence();
        }
    }
}
