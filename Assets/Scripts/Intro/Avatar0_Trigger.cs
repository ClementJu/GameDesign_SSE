using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar0_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("WindowTrigger"))
        {
            GameObject.Find("IntroSequence").GetComponent<Sequence>().NextSequence();
        }
    }
}
