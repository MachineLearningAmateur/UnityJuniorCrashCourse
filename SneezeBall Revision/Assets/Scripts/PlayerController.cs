using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private Rigidbody playerRb;
    private float zBound = 13.0f;
    private float xBound = 24.0f;
    public bool powerup;
    public bool movement;
    private Coroutine currCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        powerup = false;
        movement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            MovePlayer();
            ConstrainPlayerPosition();
        }
    }

    //sets player velocity to be fixed when input is given;
    void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerRb.velocity = move * speed;
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")) {
            Destroy(other.gameObject);
            if(powerup)
            {
                StopCoroutine(currCoroutine);
            }
            currCoroutine = StartCoroutine(PowerDuration());
            powerup = true;
        }
    }

    IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(3f);
        powerup = false;

    }

    public void stopMovement()
    {
        movement = false;
    }
}
