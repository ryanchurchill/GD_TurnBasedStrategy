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

    public Vector3 GetPosition()
    {
        Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            out RaycastHit raycastHit,
            float.MaxValue,
            mousePlaneLayerMask
        );
        return raycastHit.point;
    }
}
