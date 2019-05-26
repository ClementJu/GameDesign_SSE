using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_windowbreak : MonoBehaviour
{
    public GameObject Avatar;
    // Start is called before the first frame update
    void Start()
    {
        Avatar.GetComponent<Animator>().Play("Window");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
