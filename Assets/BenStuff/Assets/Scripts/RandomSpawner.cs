using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float outerRadius = 100;
    public int spawnnumber;
    public float distanceflt;


    // Start is called before the first frame update
    void Start()
    {
        //Spawn
        if (Vector2.Distance(transform.position, GameObject.Find("CM vcam1").transform.position) > distanceflt)
        {
            for (int i = 0; i < spawnnumber; i++)
            {
                SpawnObjectAtRandom();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnObjectAtRandom();
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * outerRadius;

        Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }

    //Draw Circle
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, outerRadius);
    }
}
