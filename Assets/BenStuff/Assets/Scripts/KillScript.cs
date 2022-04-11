using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float time;
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {



        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}