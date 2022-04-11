﻿using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera myCam;

    //graphical
    [SerializeField]
    RectTransform boxVisual;

    //logical
    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        //when clicked
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }

        //when dragging
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        //when release click
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
        }
        else
        {
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
        
    }


    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelection()
    {
        //Do X calculation
        if (Input.mousePosition.x < startPosition.x)
        {
            //Dragging left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            //Dragging right
            selectionBox.xMin = startPosition.x; 
            selectionBox.xMax = Input.mousePosition.x;

        }

        //Do Y calculation
        if (Input.mousePosition.y < startPosition.y)
        {
            //Dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;

        }
        else
        {
            //Dragging up
            selectionBox.yMin = startPosition.y; 
            selectionBox.yMax = Input.mousePosition.y;

        }

    }

    void SelectUnits()
    {
        //loop through all the units
        foreach (var unit in UnitSelections.Instance.unitList)
        {
            //if unit is within the bounds of the selection rect
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                //if any unit is within the selection add them to selection
                UnitSelections.Instance.DragSelect(unit);
            }

        }
    }
}
