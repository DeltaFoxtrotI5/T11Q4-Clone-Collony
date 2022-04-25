using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyScript : MonoBehaviour
{
    int randomTarget;
    public Transform target;
    private Rigidbody2D rb2;
    public float thrustScale;
    // Start is called before the first frame update
    void Start()
    {
        GetNewTarget();
        rb2 = GetComponent<Rigidbody2D>();
    }
    void GetNewTarget()
    {
        GameObject[] varyTargets;
        varyTargets = GameObject.FindGameObjectsWithTag("Clone");
        if (varyTargets.Length > 0)
        {
            randomTarget = Random.Range(0, varyTargets.Length);
            target = varyTargets[randomTarget].transform;
        }
    }
    void followMouse()
        {

            Vector2 direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
            transform.up = direction;

            //MoveForward
            rb2.AddForce(transform.up * thrustScale * Time.deltaTime);
        }


    // Update is called once per frame
    void Update()
    {
        followMouse();

        if (target == null)
        {
            GetNewTarget();
        }
    }

    private void OnCollision2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clone")
        {
            Destroy(this.gameObject);
        }
    }
}
