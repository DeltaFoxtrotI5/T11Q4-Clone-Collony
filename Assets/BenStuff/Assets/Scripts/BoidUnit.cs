﻿using System.Collections;
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
    public bool isSelected;
    public int isFed;
    public AudioSource hey;
    public AudioSource hi;
    // Start is called before the first frame update
    void Start()
    {
        
        //Get RigidBody 2D
        rb2 = GetComponent<Rigidbody2D>();
       // isSelected = true;
        isSelected = false;
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
        if(isSelected == true)
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

        ////Unlimited Power
        //if (Input.GetKeyDown("space"))
        //{
        //    isFed--;
        //    Instantiate(boid);
        //}

        //outline
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject cw = collision.gameObject;
        Rigidbody2D cwrb = cw.GetComponent<Rigidbody2D>();
        
        //Collision Effects/Ouch
        if (rb2.velocity.magnitude - cwrb.velocity.magnitude > ouchSpeed)
        {
            Debug.Log("Contact!!!");
            touch.pitch = Random.Range(0.8f, 1.3f);
            touch.Play();
            Instantiate(collide, boid.transform);
            Instantiate(collideSparks, boid.transform);
        }

        //teamUp
        if (collision.gameObject.tag.Equals("Clone") && collision.gameObject.GetComponent<BoidUnit>().isSelected == true && isSelected == false)
        {
            hi.pitch = Random.Range(0.8f, 1.3f);
            hi.Play();
            isSelected = true;
        }

        //Eat Food
        if (collision.gameObject.tag.Equals("Food"))
        {
            isFed++;
        }
    }


    

}
