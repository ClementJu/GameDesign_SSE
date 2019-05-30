using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTrigger : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip boom;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Explosion")) { 
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            audioSource.PlayOneShot(boom,0.5f);
        }
        if (col.gameObject.name.Contains("WindowTrigger"))
        {
            GameObject.Find("IntroSequence").GetComponent<Sequence>().NextSequence();
        }
    }
}
