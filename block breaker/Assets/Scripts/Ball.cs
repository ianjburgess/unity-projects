using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    public Rigidbody2D rb;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private AudioSource[] sounds;
    private AudioSource bounce;
    private AudioSource hit;

	// Use this for initialization
	void Start () {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

        rb = GetComponent<Rigidbody2D>();
        sounds = GetComponents<AudioSource>();
        bounce = sounds[0];
        hit = sounds[1]; 
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)    {
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0))    {
                hasStarted = true;
                rb.velocity = new Vector2(2f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if(hasStarted) {
            if(collision.gameObject.tag == "Breakable") {
                hit.Play();
                GetComponent<Rigidbody2D>().velocity += tweak;
            } else {
                bounce.Play();
                GetComponent<Rigidbody2D>().velocity += tweak;
            }
        }
    }

}
