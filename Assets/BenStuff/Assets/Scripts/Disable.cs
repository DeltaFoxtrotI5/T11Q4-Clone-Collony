using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public int rd;
    //void Start()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //}
    // Update is called once per frame
    void Update()
    {
       if (Vector2.Distance(transform.position, Camera.main.transform.position) > rd)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
