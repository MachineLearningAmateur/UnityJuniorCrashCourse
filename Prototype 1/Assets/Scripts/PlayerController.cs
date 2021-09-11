using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private const float turnSpeed = 45f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    void Awake()
    {
        //must give each wheel a little torque or the wheel colliders would not work properly
        foreach (WheelCollider w in allWheels)
            w.motorTorque = 0.000001f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //grabs player input from input manager.
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //We'll move the vehicle forward.

        if (isOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            //turns the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // for kph, change 2.237 to 3.6
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
