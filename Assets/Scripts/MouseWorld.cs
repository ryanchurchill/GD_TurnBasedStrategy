using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    private void Awake()
    {
        instance = this;
    }

    public static MouseWorld GetInstance()
    {
        return instance;
    }

    [SerializeField] private LayerMask mousePlaneLayerMask;
    [SerializeField] private LayerMask unitLayerMask;

    public LayerMask MousePlaneLayerMask { get => mousePlaneLayerMask; }
    public LayerMask UnitLayerMask { get => unitLayerMask; }

    public RaycastHit? GetRaycast(LayerMask layerMask)
    {
        if (
        Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            out RaycastHit raycastHit,
            float.MaxValue,
            layerMask
        ))
        {
            return raycastHit;
        }
        return null;        
    }
}
