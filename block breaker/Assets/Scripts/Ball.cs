using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Paddle paddle;
    public Rigidbody2D rb;
    private bool hasStarted = false;

    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)    {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))    {
                hasStarted = true;
                rb.velocity = new Vector2(2f, 10f);
            }
        }
	}
}
