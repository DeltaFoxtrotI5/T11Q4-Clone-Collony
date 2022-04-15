using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreditR : MonoBehaviour
{

    private static int nScreens = 6;
    private GameObject[] creditScenes = new GameObject[nScreens];
    private static int swapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //for each credit scene, add a refrence here
        creditScenes[0] = GameObject.Find("Credit1");
        creditScenes[1] = GameObject.Find("Credit2");
        creditScenes[2] = GameObject.Find("Credit3");
        creditScenes[3] = GameObject.Find("Credit4");
        creditScenes[4] = GameObject.Find("Credit5");
        creditScenes[5] = GameObject.Find("Credit6");

        //turn all scenes off
        for (int i = 0; i < nScreens; i++)
        {
            creditScenes[i].SetActive(false);
        }
        //turn back on the "0th"
        creditScenes[0].SetActive(true);

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int CurrentScene = swapCount % nScreens;
            creditScenes[CurrentScene].SetActive(false);
            swapCount++;
            CurrentScene = swapCount % nScreens;
            creditScenes[CurrentScene].SetActive(true);
            Debug.Log(CurrentScene);
        }


    }
}
