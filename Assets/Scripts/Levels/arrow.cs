using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private GameObject player;
    private GameObject arrowSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        arrowSprite = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().MovingStatus())
        {
            arrowSprite.SetActive(false);
        }
        else
        {
            arrowSprite.SetActive(true);
            FaceMouse();
        }
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
