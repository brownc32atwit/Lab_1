using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed = 2.0f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Define AI behavior for the characters
    void Update()
    {
        // Implement Simple AI to Move towards the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Cube"))
    //     {
    //         GameController.npcScore--;
    //         // UpdateScore();
    //         other.gameObject.SetActive(false);
    //     }
    // }
}
