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
    private int boxColliderCount; // for one-sided platforms
    private bool dead; // useful for death screen
    private float timeOfDeath; // useful for death screen
    private bool isFellowY;

    // Oxygen level
    private float barDisplay; //current progress
    public bool needOxygen;
    private Vector2 posOxygen;
    private Vector2 sizeOxygen;
    private Texture2D emptyTexOxygen;
    private Texture2D fullTexOxygen;
    private Texture2D fullScreenTex;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isMoving = false;
        startPos = transform.position;
        boxColliderCount = 0;
        isFellowY = false;

        // oxygen bar and related textures
        posOxygen = new Vector2(20, 40);
        sizeOxygen = new Vector2(240, 40);
        startLevel = Time.time;

        emptyTexOxygen = new Texture2D(290, 40);
        fullTexOxygen = new Texture2D(290, 40);

        Color fillColor = new Color(1, 0.6f, 0.2f);
        Color[] fillColorArray = emptyTexOxygen.GetPixels();

        for (int i = 0; i < fillColorArray.Length; ++i)
        {
            fillColorArray[i] = fillColor;
        }

        emptyTexOxygen.SetPixels(fillColorArray);
        emptyTexOxygen.Apply();


        // death screen
        fullScreenTex = new Texture2D(Screen.width, Screen.height);

        Color fillColorDS = new Color(0.7f, 0f, 0.1f, 0.5f);
        Color[] fillColorArrayDS = fullScreenTex.GetPixels();

        for (int i = 0; i < fillColorArrayDS.Length; ++i)
        {
            fillColorArrayDS[i] = fillColorDS;
        }

        fullScreenTex.SetPixels(fillColorArrayDS);
        fullScreenTex.Apply();

        dead = false;
        timeOfDeath = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        ManageOxygen();
        BackToMainMenu();
        if (dead)
        {
            if (Time.time - timeOfDeath > 1f)
            {
                dead = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
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
            if (!isMoving & CanMove(direction))
            {
                AudioSource jumpSound = this.gameObject.transform.Find("jumpSound").gameObject.GetComponent<AudioSource>();
                jumpSound.Play();
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

    bool CanMove(Vector2 direction)
    {
        // returns false if the player tries to jump in the direction of the player he's currently standing on
        // otherwise returns true
        return (Vector2.Angle(direction, transform.up) < 90.0);
    }

    void ManageOxygen()
    {
        if (needOxygen)
        {
            barDisplay = (Time.time - startLevel) * 0.05f;
            if (barDisplay > 1.0f && !dead)
            {
                Death();
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Platform"))
        {
            // if the player came from the top of a platform -> make him stop and stand on it
            if (boxColliderCount != 2)
            {
                isMoving = false;
                AudioSource landSource = this.gameObject.transform.Find("landSound").gameObject.GetComponent<AudioSource>();
                landSource.Play();
                rigidbody2D.velocity = new Vector2(0,0);
                boxColliderCount = 0;

                print("Points colliding: " + col.contacts.Length);
                print("First normal of the point that collide: " + col.contacts[0].normal);

                Vector2 normCol = col.contacts[0].normal;
                Vector2 direction = new Vector2(normCol.x - transform.position.x, normCol.y - transform.position.y);
                transform.up = normCol;
            }
            // if the player came from the bottom of a platform -> go through it without stopping
            else
            {
                boxColliderCount = 0;
            }
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
            //print("------ END");
            //Death();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (col.gameObject.name.Contains("Platform"))
        {
            // if the player goes through one of the colliders under a platform
            // allow to know where the player is coming from (top or bottom of a platform)
            // useful for one-sided platforms
            if (col is BoxCollider2D)
            {
                boxColliderCount++;
            }
        }
        else if(col.gameObject.name.Contains("FellowY"))
        {
            isFellowY = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("FellowY"))
        {
            isFellowY = false;
        }
    }

    void Death()
    {
        dead = true;
        timeOfDeath = Time.time;
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

    void drawDeathScreen()
    {
        if (dead)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), fullScreenTex);
        }
    }

    void OnGUI()
    {
        drawOxygenBar();
        drawDeathScreen();
    }

    public bool MovingStatus()
    {
        return isMoving;
    }

    public void BackToMainMenu()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }

    }

    public bool FellowY()
    {
        return isFellowY;
    }
}
