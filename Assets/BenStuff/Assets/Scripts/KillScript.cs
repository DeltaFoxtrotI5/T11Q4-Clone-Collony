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
        if (this.gameObject.tag.Equals("Food"))
        {
            GameObject.Find("Counter").GetComponent<EverythingCounter>().foodnum--;
        }
        if (this.gameObject.tag.Equals("Astroid"))
        {
            GameObject.Find("Counter").GetComponent<EverythingCounter>().astroidsnum--;
        }
        if (this.gameObject.tag.Equals("Enemy"))
        {
            GameObject.Find("Counter").GetComponent<EverythingCounter>().enemynum--;
        }
        Destroy(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}