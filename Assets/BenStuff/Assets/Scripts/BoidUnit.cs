using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BoidUnit : MonoBehaviour
{
    public AudioSource die;
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
    public bool isSelected;
    public int isFed;
    public AudioSource hey;
    public AudioSource hi;
    public bool unlimitedPower;
    public int maxSpeed;
    //Stop At Mouse
    public bool sam;
    //Slow Down At Mouse
    public bool sdam;
    //Divide number
    public float sdamn;

    // Start is called before the first frame update
    void Start()
    {
        
        //Get RigidBody 2D
        rb2 = GetComponent<Rigidbody2D>();
       // isSelected = true;
        isSelected = false;
        isFed = 0;
        GameObject.Find("Counter").GetComponent<Score>().boidNumber++;

        //GameObject.Find("Cm vcam1").GetComponent<CinemachineVirtualCamera>().Follow = this.transform;
    }

    //navigation to mouse////////////////////////////////////////
    void followMouse()
    {
        //Point to Mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        //MoveForward
        rb2.AddForce(transform.up * thrustScale * Time.deltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        //limity velocity magnitude
        if(rb2.velocity.magnitude > maxSpeed)
        {
            rb2.velocity = Vector2.ClampMagnitude(rb2.velocity, maxSpeed);
        }

        //Reset Rotation/Stabilize boids.
        if (Input.GetMouseButtonDown(0))
        {
            rb2.angularVelocity = 0;
        }

        //When RightClick
        if (Input.GetMouseButton(1))
        {
            isSelected = false;
        }

        //Follow Mouse
        if (Input.GetMouseButton(0) && isSelected == true)
        {
            followMouse();
        }

        //If unit is selected
        //if (isSelected == true)
        //{
        //    GameObject.Find("Cm vcam1").GetComponent<CinemachineVirtualCamera>().Follow = this.transform;
        //}
        //else
        //{
        //    GameObject.Find("Cm vcam1").GetComponent<CinemachineVirtualCamera>().Follow = null;
        //}
            ///boid Highlight
            if (isSelected == true)
        {
            boid.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            boid.transform.GetChild(0).gameObject.SetActive(false);
        }

        ////Rotate
        //float rotation = rotateScale * Input.GetAxis("Horizontal");
        //transform.Rotate(new Vector3(0, 0, -rotation));

        ////Move Foreward and backward
        //float thrust = thrustScale * Input.GetAxis("Vertical");
        //rb2.AddForce(transform.up * thrust);

        //Clone Power
        if (Input.GetKeyDown("space") && isFed > 0)
        {
            isFed--;
            Instantiate(boid);
        }

        //Unlimited Power
        if (unlimitedPower == true)
        {
            if (Input.GetKeyDown("space"))
            {
                Instantiate(boid);
            }
        }
        

        //Outline
        if (isFed > 0)
        {
            boid.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            boid.transform.GetChild(1).gameObject.SetActive(false);
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

    public void Killob()
    {
        Destroy(this.gameObject);
    }

    //Ouch protocol
    void Ouch()
    {
        touch.pitch = Random.Range(0.8f, 1.3f);
        touch.Play();
        Instantiate(collide, boid.transform);
        Instantiate(collideSparks, boid.transform);
        Invoke("Killob", 1);
    }

    //On Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject cw = collision.gameObject;
        Rigidbody2D cwrb = cw.GetComponent<Rigidbody2D>();
        
        //Collision Effects/Ouch
        if (rb2.velocity.magnitude - cwrb.velocity.magnitude > ouchSpeed)
        {
            Debug.Log("Contact!!!");
            Ouch();
        }

        //Die on touch
        if (collision.gameObject.name == "Death")
        {
            GameObject.Find("Counter").GetComponent<Score>().boidNumber--;
            Destroy(this.gameObject);
        }

        //teamUp
        if (collision.gameObject.tag.Equals("Clone") && collision.gameObject.GetComponent<BoidUnit>().isSelected == true && isSelected == false)
        {
            hi.pitch = Random.Range(0.8f, 1.3f);
            hi.Play();
            isSelected = true;
        }

        //Reach Mouse
        if (collision.gameObject.name.Contains("Mouse"))
        {
            //Slow Down At Mouse
            if (sdam == true)
            {
                rb2.velocity = Vector2.one / sdamn;
            }

            //Stop At Mouse
            if (sam == true)
            {
                rb2.velocity = Vector2.zero;
            }
        }

        //Eat Food
        if (collision.gameObject.tag.Equals("Food"))
        {
            isFed++;
        }
    }
}
