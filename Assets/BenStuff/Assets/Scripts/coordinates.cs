using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coordinates : MonoBehaviour
{
    public int X;
    public int Y;

    public Text uitextX;
    public Text uitectY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uitextX.text = this.gameObject.transform.position.x.ToString();
        uitectY.text = this.gameObject.transform.position.y.ToString();
    }
}
