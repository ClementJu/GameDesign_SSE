
using UnityEngine;

public class rotatingEnnemy : MonoBehaviour
{
    public float radius;
    private Vector2 initialPosition;
    public int direction;
    public int speed;
    private float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        // Opposite to the clockwise direction
        if (direction == 0)
        {
            angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
            float newX = Mathf.Cos(angle) * radius + initialPosition.x;
            float newY = Mathf.Sin(angle) * radius + initialPosition.y;
            transform.position = new Vector2(newX, newY);

        }

        //  clockwise direction
        else {
            angle -= speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
            float newX = Mathf.Cos(angle) * radius + initialPosition.x;
            float newY = Mathf.Sin(angle) * radius + initialPosition.y;
            transform.position = new Vector2(newX, newY);
        }
        
    }
}
