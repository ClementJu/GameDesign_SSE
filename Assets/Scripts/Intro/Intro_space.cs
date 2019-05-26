using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_space : MonoBehaviour
{
    public Camera oldCam;
    public Camera newCam;
    // Start is called before the first frame update
    void Start()
    {
        oldCam.gameObject.SetActive(false);
        newCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
