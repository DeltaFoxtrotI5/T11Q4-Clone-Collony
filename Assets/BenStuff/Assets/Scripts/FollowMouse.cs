using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
        //else
        //{
        //    transform.position = new Vector2(GameObject.Find("BoidUnit").transform.position.x, GameObject.Find("BoidUnit").transform.position.y) ;
        //}
        
    }
}
