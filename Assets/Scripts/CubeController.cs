using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CubeController : OVRGrabbable
{
    private GameController scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Add to score when the player hits a cube
            GameController.score++;
            // Destroy the cube
            Destroy(gameObject);
        }
        // Character tag for NPC
        else if (collision.gameObject.tag == "Character")
        {
            GameController.npcScore--;
            Destroy(gameObject);
        }
    }

    // Override the base GrabBegin function
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        GameController.OnCubeGrabbed();
    }

    // Update is called once per frame
    void Update() { }
}
