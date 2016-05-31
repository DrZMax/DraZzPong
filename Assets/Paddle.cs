using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float speed = 25;
    public string axis = "Vertical";
    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw(axis);
        rBody.velocity = new Vector2(0, vertical) * speed;
    }
}
