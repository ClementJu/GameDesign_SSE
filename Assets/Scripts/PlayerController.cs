using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    public float PlayerSpeed = 100.0f;
    private Rigidbody2D rigidbody2D;
    private Vector3 startPos;

    // Oxygen level
    public float barDisplay; //current progress
    public Vector2 posOxygen;
    public Vector2 sizeOxygen;
    public Texture2D emptyTexOxygen;
    public Texture2D fullTexOxygen;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isMoving = false;
        startPos = transform.position;
        posOxygen = new Vector2(20, 40);
        sizeOxygen = new Vector2(60, 20);
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        ManageOxygen();
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

    void ManageOxygen()
    {
        barDisplay = Time.time * 0.05f;
        if (barDisplay > 1.0f)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Platform"))
        {
            isMoving = false;
            rigidbody2D.velocity = new Vector2(0,0);
        }
        else if (col.gameObject.name.Contains("Enemy"))
        {
            Death();
        }
    }

    void Death()
    {
        transform.position = startPos;
        rigidbody2D.velocity = new Vector2(0, 0);
        isMoving = false;
    }

    void drawOxygenBar()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(posOxygen.x, posOxygen.y, sizeOxygen.x, sizeOxygen.y));
        GUI.Box(new Rect(0, 0, sizeOxygen.x, sizeOxygen.y), emptyTexOxygen);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, sizeOxygen.x * barDisplay, sizeOxygen.y));
        GUI.Box(new Rect(0, 0, sizeOxygen.x, sizeOxygen.y), fullTexOxygen);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void OnGUI()
    {
        drawOxygenBar();
    }
}
