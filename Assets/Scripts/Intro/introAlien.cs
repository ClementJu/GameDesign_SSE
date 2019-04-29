using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introAlien : MonoBehaviour
{
    public GameObject NPCAlive;
    public GameObject NPCDead;
    // Start is called before the first frame update
    void Start()
    {
        NPCAlive.SetActive(false);
        NPCDead.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
