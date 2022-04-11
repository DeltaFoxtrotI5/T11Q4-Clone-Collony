using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }


    void Awake()
    {
        //If instance exists already and isn't this one
        if(_instance != null && _instance != this)
        {
            //we destroy this
            Destroy(this.gameObject);
        }
        else
        {
            //make this the instance
            _instance = this;
        }
    }

    public void Update()
    {
        //When RightClick
        if (Input.GetMouseButton(1))
        {
            DeselectAll();
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<BoidUnit>().isSelected = true;
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<BoidUnit>().isSelected = true;
        }
        else
        {
            //unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitToAdd.GetComponent<BoidUnit>().isSelected = false;
            unitsSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<BoidUnit>().isSelected = true;
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.GetComponent<BoidUnit>().isSelected = false;
        }
        unitsSelected.Clear();
        
    }

    public void Deselect(GameObject unitToDeselect)
    {

    }
}
