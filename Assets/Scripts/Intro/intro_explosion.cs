using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_explosion : MonoBehaviour
{
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject.Find("IntroSequence").GetComponent<Sequence>().NextSequence();
            Destroy(gameObject);
        }
    }
}
