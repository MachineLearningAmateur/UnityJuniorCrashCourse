using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    public float bounce;
    public float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private BoxCollider backgroundY;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        gameOver = false;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        backgroundY = GameObject.Find("Background").GetComponent<BoxCollider>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * bounce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && transform.position.y <= backgroundY.size.y - 6)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
            playerAudio.PlayOneShot(boingSound);
        }

        if (transform.position.y > backgroundY.size.y)
        {
            playerRb.velocity = Vector3.zero;
        }

        if (transform.position.y < backgroundY.size.y/100 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * .5f, ForceMode.Impulse);
            playerAudio.PlayOneShot(boingSound);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
