using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent2Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject agent1;
    public float speed = 5.0f;
    public float agent1DistanceThreshold = 3.0f;

    private enum State
    {
        ChasePlayer,
        ChaseTarget,
        Flee
    }

    private State currentState = State.ChasePlayer;

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        float agent1Distance = Vector3.Distance(transform.position, agent1.transform.position);

        if (agent1Distance <= agent1DistanceThreshold)
        {
            currentState = State.Flee;
        }
        else if (playerDistance < targetDistance && agent1Distance > agent1DistanceThreshold)
        {
            currentState = State.ChasePlayer;
        }
        else if (targetDistance < playerDistance && agent1Distance > agent1DistanceThreshold)
        {
            currentState = State.ChaseTarget;
        }
        

        switch (currentState)
        {
            case State.ChasePlayer:
                ChasePlayer();
                break;

            case State.ChaseTarget:
                ChaseTarget();
                break;

            case State.Flee:
                Flee();
                break;
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void ChaseTarget()
    {
        Vector3 direction = target.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void Flee()
    {
        Vector3 direction = transform.position - agent1.transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
