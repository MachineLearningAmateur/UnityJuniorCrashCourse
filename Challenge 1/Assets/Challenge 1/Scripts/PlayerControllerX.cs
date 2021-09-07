using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 25.0f;
    private float rotationSpeed = 50.0f;
    private float propellerRotation = 500.0f;
    private float verticalInput;
    private GameObject propeller;

    // Start is called before the first frame update
    void Start()
    {
         propeller = GameObject.Find("Propeller");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        //rotates the propeller when plane moves
        propeller.transform.Rotate(Vector3.forward * Time.deltaTime * propellerRotation);
    }
}
