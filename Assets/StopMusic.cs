using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            this.gameObject.GetComponent<AudioSource>().pitch *= 0;
        }
        else
        {
            this.gameObject.GetComponent<AudioSource>().pitch *= 1;
        }
    }
}
