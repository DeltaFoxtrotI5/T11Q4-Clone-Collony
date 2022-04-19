using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMFT : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
