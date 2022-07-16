using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseWorld mouseWorld = MouseWorld.GetInstance();

            // check for unit collision
            RaycastHit? unitCollision = mouseWorld.GetRaycast(mouseWorld.UnitLayerMask);
            if (unitCollision.HasValue)
            {
                if (unitCollision.Value.transform.TryGetComponent<Unit>(out Unit clickedUnit))
                {
                    selectedUnit = clickedUnit;
                }
            }
            else
            {
                // check for mouse plane collision
                RaycastHit? mousePlaneCollision = mouseWorld.GetRaycast(mouseWorld.MousePlaneLayerMask);
                if (mousePlaneCollision.HasValue)
                {
                    selectedUnit.SetDestination(mousePlaneCollision.Value.point);
                }
                
            }
            
        }
    }

    private void HandleUnitSelection()
    {

    }
}
