using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent1Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject target;

    public float speed = 5.0f;
    public float playerDistanceThreshold = 5.0f;
    public float targetDistanceThreshold = 3.0f;
    bool activated = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        if (targetDistance < targetDistanceThreshold)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }

        if (activated)
        {
            if (playerDistance < playerDistanceThreshold)
            {
                // flee
                Vector3 direction = transform.position - player.transform.position;
                rb.AddForce(direction.normalized * speed, ForceMode.Force);
            }
            else
            {
                // chase
                Vector3 direction = player.transform.position - transform.position;
                rb.AddForce(direction.normalized * speed);
            }
        }
        else
        {
            // chase
            Vector3 direction = player.transform.position - transform.position;
            rb.AddForce(direction.normalized * speed);
        }
    }
}
