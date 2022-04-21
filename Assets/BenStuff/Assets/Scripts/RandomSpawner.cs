using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float outerRadius = 100;
    public int spawnnumber;
    public float distanceflt;
    public int objectlimit = 2;
    private int asn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Spawn
        if (GameObject.Find("Counter").GetComponent<EverythingCounter>().astroidsnum < 100)
        {
            Invoke("SpawnTime", 1);
        }
            
    }

    void SpawnTime()
    {
        SpawnObjectAtRandom();
    }

    void SpawnObjectAtRandom()
    {
        Vector2 randomPos = new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * outerRadius;

        Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }

    //Draw Circle
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, outerRadius);
    }
}
