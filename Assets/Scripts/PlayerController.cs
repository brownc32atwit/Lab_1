using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // rb.AddForce(movement * speed);

        // Get input from the Oculus Touch controller
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        // Apply input as movement
        Vector3 move = new Vector3(input.x, 0, input.y);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
