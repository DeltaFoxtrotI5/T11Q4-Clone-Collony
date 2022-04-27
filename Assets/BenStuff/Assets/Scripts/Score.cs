using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject loseMenuUI;
    public GameObject Sizelist;

    public static int boidNumber;
    public Text uiText;

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
            loseMenuUI.SetActive(true);
        }

        uiText.text = boidNumber.ToString();
    }
}
