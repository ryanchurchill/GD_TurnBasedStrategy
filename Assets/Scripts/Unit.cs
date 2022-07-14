using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.T))
        {
            SetDestination(new Vector3(4, 0, 4));
        }
    }

    private void SetDestination(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Move()
    {
        float stoppingDistance = .1f;        
        if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
