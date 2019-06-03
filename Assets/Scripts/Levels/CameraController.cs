using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float yPos;
    private bool inZone;


    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(player.transform.position.x, 0.9f*player.transform.position.y, -10f);

        if (player.GetComponent<PlayerController>().FellowY())
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.5f);
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10f);
        }
    }
}
