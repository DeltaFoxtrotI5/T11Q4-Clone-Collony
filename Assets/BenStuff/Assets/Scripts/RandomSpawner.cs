using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float outerRadius = 100;
    public int spawnnumber;


    // Start is called before the first frame update
    void Start()
    {
        //Spawn
        for(int i = 0; i < spawnnumber; i++)
        {
            SpawnObjectAtRandom();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
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
