using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void SetDestination(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Move()
    {
        float stoppingDistance = .1f;        
        if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
        {
            unitAnimator.SetBool("IsWalking", true);
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;            
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        } else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    }
}
