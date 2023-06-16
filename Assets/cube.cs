using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float minPosition = -10f;
    public float maxPosition = 10f;
    public float speed = 2.0f;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector3(0,2.85f,0);
    }

    private void Update()
    {
        MoveTowardsTargetPosition();
    }

    private void SetRandomTargetPosition()
    {
        float randomX = Random.Range(minPosition, maxPosition);
        float randomZ = Random.Range(minPosition, maxPosition);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void MoveTowardsTargetPosition()
    {
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            SetRandomTargetPosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
