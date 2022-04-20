using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float outerRadius = 100;
    public int spawnnumber;
    public float distanceflt;
    public int objectlimit = 100;
    EverythingCounter spwn;

    // Start is called before the first frame update
    void Start()
    {

        

        //Spawn
      for (int i = 0; i < spawnnumber; i++)
      {
          SpawnObjectAtRandom();
      }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && (spwn.astroidsnum < objectlimit))
        {
            SpawnObjectAtRandom();
        }
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
