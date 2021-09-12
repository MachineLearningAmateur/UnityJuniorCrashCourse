using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody playerRb;
    private Rigidbody enemyRb;
    private Vector3 difference;
    public float speed;
    private Vector3 scale;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        enemyRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        difference = (playerRb.transform.position - enemyRb.transform.position).normalized;
        enemyRb.AddForce(difference * speed, ForceMode.Impulse);
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 50)
        {
            Debug.Log("Game Over");
            gameManager.GameOver();
        }
    }

    //bounce the balls off the walls
    void ReflectedVector() 
    {
        if (transform.position.x > 22)
        {
            enemyRb.AddForce(Vector3.Reflect(transform.position, Vector3.right), ForceMode.Impulse);
        }

        if (transform.position.x < -22)
        {
            enemyRb.AddForce(Vector3.Reflect(transform.position, Vector3.right), ForceMode.Impulse);
        }

        if (transform.position.z > 10)
        {
            enemyRb.AddForce(Vector3.Reflect(transform.position, Vector3.forward), ForceMode.Impulse);
        }

        if (transform.position.z < -10)
        {
            enemyRb.AddForce(Vector3.Reflect(transform.position, Vector3.forward), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ReflectedVector();
        }
        else if (collision.gameObject.CompareTag("Player") && player.powerup)
        {          
            gameManager.addScore(Mathf.RoundToInt(transform.localScale.x * 5));
            Destroy(gameObject);
        }
        else
        {
            transform.localScale = 1.2f * scale;
            scale = transform.localScale;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            gameManager.addScore(Mathf.RoundToInt(transform.localScale.x * 5));
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
