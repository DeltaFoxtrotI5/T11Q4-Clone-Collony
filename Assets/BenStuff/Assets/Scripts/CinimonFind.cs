using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinimonFind : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    int randomTarget;
    Quaternion newRot;
    Vector3 relPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow == null)
        {
            GetNewTarget();
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = target;
        }
    }

    void GetNewTarget()
    {
        GameObject[] possibleTargets;
        possibleTargets = GameObject.FindGameObjectsWithTag("Clone");
        if(possibleTargets.Length > 0)
        {
            randomTarget = Random.Range(0, possibleTargets.Length);
            target = possibleTargets[randomTarget].transform;
        }
    }
}
