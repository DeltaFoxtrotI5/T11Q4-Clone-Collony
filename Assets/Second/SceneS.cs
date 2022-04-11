using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneS : MonoBehaviour
{

    public void OnButtonPress()
    {
        SceneManager.LoadScene("Test scene");
    }
}
