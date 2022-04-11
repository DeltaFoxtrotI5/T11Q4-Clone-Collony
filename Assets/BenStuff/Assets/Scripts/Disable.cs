using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject target;

    //void Start()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //}
    // Update is called once per frame
    void Update()
    {
       if (Vector2.Distance(transform.position, target.transform.position) > 100.0f)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
