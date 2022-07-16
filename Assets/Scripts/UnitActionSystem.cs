using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit selectedUnit;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of UnitActionSystem " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

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
                    SetSelectedUnit(clickedUnit);
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

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        //if (OnSelectedUnitChanged != null)
        //{
        //    OnSelectedUnitChanged(this, EventArgs.Empty);
        //}
        // ^^ replaced by:
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);

    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
