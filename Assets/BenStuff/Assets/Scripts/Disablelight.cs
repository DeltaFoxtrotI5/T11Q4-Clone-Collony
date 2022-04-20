using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Rendering;

public class Disablelight : MonoBehaviour
{
    public int rd;
    public int dd = 200;
    //void Start()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //}
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Camera.main.transform.position) > rd)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}