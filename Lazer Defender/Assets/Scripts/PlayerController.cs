using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject attack;
    public float attackSpeed;
    public float firingRate = 0.2f;
    public float padding = 1f;
    public float speed = 15.0f;
    private float xmax;
    private float xmin;


    // On Start Functions
    private void Start()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    // Update is called once per frame
    private void Update()
    {
        // PLAYER CONTROLS //
        // Player movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed*Time.deltaTime;
        }
        // Combat controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        // Restrict Player to play space
        var newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void Fire()
    {
        var attackBasic = Instantiate(attack, transform.position, Quaternion.identity) as GameObject;
        attackBasic.GetComponent<Rigidbody2D>().velocity = new Vector3(0, attackSpeed, 0);
    }
}