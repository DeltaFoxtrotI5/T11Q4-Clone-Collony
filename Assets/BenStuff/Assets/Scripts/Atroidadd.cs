using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atroidadd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Counter").GetComponent<EverythingCounter>().astroidsnum++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
