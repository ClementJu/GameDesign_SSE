using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_windowbreak : MonoBehaviour
{
    public GameObject Avatar;
    public GameObject Plant1;
    public GameObject Plant2;
    public GameObject Plant3;
    public GameObject Plant4;
    // Start is called before the first frame update
    void Start()
    {
        Avatar.GetComponent<Animator>().Play("Window");
        Plant1.GetComponent<Animator>().Play("Fly1");
        Plant2.GetComponent<Animator>().Play("Fly2");
        Plant3.GetComponent<Animator>().Play("Fly3");
        Plant4.GetComponent<Animator>().Play("Fly4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
