using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnnemy : MonoBehaviour
{
   
    private int direction;
    public float maxDist;
    public float speed;
    private Vector2 initialPosition;
    public Vector3 directionOfMove;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        //int speed = 5;
        direction = 1;
        //maxDist = 2;
        //directionOfMove = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        directionOfMove = directionOfMove.normalized;
        if (Vector2.Distance(initialPosition, transform.position) >= maxDist)
        {
            direction = -direction;
            transform.position += direction * directionOfMove * speed * Time.deltaTime;
            //Debug.Log(direction.ToString());
        }


        if (direction == 1)
        {
                transform.position += directionOfMove* speed * Time.deltaTime;
               
        }
        else {
                transform.position -= directionOfMove * speed * Time.deltaTime;
        }
            
        

     
    }
}
