using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidUnit : MonoBehaviour
{

    public float rotateScale;
    public float thrustScale;
    private Rigidbody2D rb2;
    public GameObject flames;
    public GameObject boid;
    public AudioSource touch;
    public GameObject collide;
    public GameObject collideSparks;
    public float ouchSpeed;
    public float dizzySpeed;
    public AudioSource dizzySound;


    // Start is called before the first frame update
    void Start()
    {
        
        //Get RigidBody 2D
        rb2 = GetComponent<Rigidbody2D>();

    }

    
    void followMouse()
    {
        //Point to Mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        //MoveForward
        rb2.AddForce(transform.up * thrustScale);
    }

    // Update is called once per frame
    void Update()
    {
        //Reset Rotation/Stabilize boids.
        if (Input.GetMouseButtonDown(0))
        {
            rb2.angularVelocity = 0;
        }

        //Follow Mouse
        if (Input.GetMouseButton(0) && UnitSelections.Instance)
        {
            followMouse();
        }
        

        //Rotate
        float rotation = rotateScale * Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -rotation));

        //Move Foreward and backward
        float thrust = thrustScale * Input.GetAxis("Vertical");
        rb2.AddForce(transform.up * thrust);

        //Clone Power
        if (Input.GetKeyDown("space"))
        {
            Instantiate(boid);
        }



        //Dizzy
        if (rb2.angularVelocity > dizzySpeed)
        {
            Debug.Log("Dizzy");
            //dizzySound.Play();
        }
        if (rb2.angularVelocity < -dizzySpeed)
        {
            Debug.Log("Dizzy");
            //dizzySound.Play();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        //Collision Effects/Ouch
        if (rb2.velocity.x > ouchSpeed)
        {
            Debug.Log("Contact!!!");
            touch.Play();
            Instantiate(collide, boid.transform);
            Instantiate(collideSparks, boid.transform);
        }
        if (rb2.velocity.x < -ouchSpeed)
        {
            Debug.Log("Contact!!!");
            touch.Play();
            Instantiate(collide, boid.transform);
            Instantiate(collideSparks, boid.transform);

        }
    }


    

}
