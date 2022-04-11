using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnoffatStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        gameObject.SetActive(false);
    }
}
