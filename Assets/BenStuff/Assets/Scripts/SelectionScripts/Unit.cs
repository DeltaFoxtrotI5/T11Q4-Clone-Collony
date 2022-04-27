
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
        Score.boidNumber++;
    }

    void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
        UnitSelections.Instance.unitsSelected.Remove(this.gameObject);
        Score.boidNumber--;
    }
}
