using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    public float PlayerSpeed = 100.0f;
    private Rigidbody2D rigidbody2D;
    private Vector3 startPos;
    float startLevel;

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
        startLevel = Time.time;

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

        if (isMoving)
        {
            transform.up = direction;
        }

        else if (Input.GetMouseButton(0))
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
        barDisplay = (Time.time - startLevel) * 0.05f;
        if (barDisplay > 1.0f)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Platform"))
        {
            print(rigidbody2D.velocity.ToString());
            if (System.Math.Abs(rigidbody2D.velocity.x) < 2 && System.Math.Abs(rigidbody2D.velocity.y) < 2)
            {
                isMoving = false;
                rigidbody2D.velocity = new Vector2(0,0);

                print("Points colliding: " + col.contacts.Length);
                print("First normal of the point that collide: " + col.contacts[0].normal);

                Vector2 normCol = col.contacts[0].normal;
                Vector2 direction = new Vector2(normCol.x - transform.position.x, normCol.y - transform.position.y);
                transform.up = normCol;
            }
            //isMoving = false;
            //rigidbody2D.velocity = new Vector2(0,0);

            //print("Points colliding: " + col.contacts.Length);
            //print("First normal of the point that collide: " + col.contacts[0].normal);

            //Vector2 normCol = col.contacts[0].normal;
            //Vector2 direction = new Vector2(normCol.x - transform.position.x, normCol.y - transform.position.y);
            //transform.up = normCol;
        }
        else if (col.gameObject.name.Contains("Enemy"))
        {
            Death();
        }
        else if (col.gameObject.name.Contains("Border"))
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("OxygenBubble"))
        {
            Destroy(col.gameObject);

            startLevel = Time.time;
        }
        else if (col.gameObject.name.Contains("End"))
        {
            print("------ END");
            Death();
        }
    }

    void Death()
    {
        //transform.position = startPos;
        //rigidbody2D.velocity = new Vector2(0, 0);
        //isMoving = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public bool MovingStatus()
    {
        return isMoving;
    }
}
