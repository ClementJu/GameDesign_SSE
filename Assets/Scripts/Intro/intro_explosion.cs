using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("IntroSequence").GetComponent<Sequence>().NextSequence();
        Destroy(gameObject);
    }
}
