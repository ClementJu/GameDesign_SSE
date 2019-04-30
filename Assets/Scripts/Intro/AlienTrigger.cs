using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTrigger : MonoBehaviour
{
    public GameObject explosion;
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
        print("Hello");
        //if (col.gameObject.name.Contains("Explosions"))
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        //}
    }
}
