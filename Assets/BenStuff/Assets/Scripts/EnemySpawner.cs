﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public AudioSource action;
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
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
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            if (Score.boidNumber > 1)
            {
                SpawnObjectAtRandom();
                //action.Play();
            }
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
