using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 15;
    private Rigidbody2D rb;
    private int startingPlayer = 1;
    public string startKey = "space";
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(startKey))
        {
            if(startingPlayer == 1)
            {
                rb.velocity = Vector2.right * speed;
            }
            else
            {
                rb.velocity = Vector2.left * speed;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "rightPaddle" || col.gameObject.name == "leftPaddle")
        {
            paddleCollision(col);
        }

        verticalWallCollision(col);

    }

    float calculatePosition(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight)
    {
        float value = (ballPosition.y - paddlePosition.y) / paddleHeight;
        return value;
    }

    void paddleCollision(Collision2D col)
    {
        float direction = 1;

        if (col.gameObject.name == "rightPaddle")
        {
            direction = -1;
        }

        if (col.gameObject.name == "leftPaddle")
        {
            direction = 1;
        }

        float y = calculatePosition(transform.position, col.transform.position, col.collider.bounds.size.y);
        Vector2 directionRebound = new Vector2(direction, y).normalized;
        rb.velocity = directionRebound * speed;
    }

    void verticalWallCollision(Collision2D col)
    {
        if(col.gameObject.name == "leftWall")
        {
            rb.velocity = Vector2.zero;
            startingPlayer = 1;
            rb.MovePosition(Vector2.zero);
        }

        if (col.gameObject.name == "rightWall")
        {
            rb.velocity = Vector2.zero;
            startingPlayer = 2;
            rb.MovePosition(Vector2.zero);
        }

    }
}
