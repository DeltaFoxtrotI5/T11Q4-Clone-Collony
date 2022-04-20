using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEaten : MonoBehaviour
{
    public AudioSource foodPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Counter").GetComponent<EverythingCounter>().foodnum++;
    }

    IEnumerator EatenCoroutine()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        foodPoint.Play();
        GameObject.Find("Counter").GetComponent<EverythingCounter>().foodnum--;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Clone"))
        {
            StartCoroutine(EatenCoroutine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
