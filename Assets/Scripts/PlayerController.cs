using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    public float PlayerSpeed = 100.0f;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

        if (Input.GetMouseButton(0))
        {
            var delta = PlayerSpeed * Time.deltaTime;
            if (!isMoving)
            {
                rigidbody2D.AddForce(direction.normalized * PlayerSpeed);
                isMoving = true;
            }
        }
        Vector2 velocity = rigidbody2D.velocity;
        if(velocity.x == 0 && velocity.y == 0)
        {
            isMoving = false;
        }
    }
}
