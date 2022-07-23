using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;

    private GridSystem gridSystem;

    // Start is called before the first frame update
    void Start()
    {
        this.gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);

        Debug.Log(new GridPosition(5, 7));
    }

    private void Update()
    {
        MouseWorld mouseWorld = MouseWorld.GetInstance();

        //Debug.Log(
        //    gridSystem.GetGridPosition(
        //        mouseWorld.GetRaycast(
        //            mouseWorld.MousePlaneLayerMask
        //        ).Value.point
        //    )
        //);
    }
}
