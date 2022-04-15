using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int boidNumber;

    // Start is called before the first frame update
    void Start()
    {
        boidNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (boidNumber == 50)
        {
            Debug.Log("Win");
        }

        if (boidNumber == 0)
        {
            Debug.Log("Lose");
        }
    }
}
