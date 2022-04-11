using UnityEngine;

public class UnitClick : MonoBehaviour
{

    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        //    if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
        //    {
        //        //If we hit a clickable object

        //        //Normal click and Shift click
        //        if (Input.GetKey(KeyCode.LeftShift))
        //        {
        //            //shift click
        //            UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
        //        }
        //        else
        //        {
        //            //normal click
        //            //UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
        //        }

        //    }
        //    else
        //    {
        //        //If we didn't && we are not clicking
        //        if (!Input.GetKey(KeyCode.LeftShift))
        //        {
        //            UnitSelections.Instance.DeselectAll();
        //        }
        //    }
        //}
    }
}
