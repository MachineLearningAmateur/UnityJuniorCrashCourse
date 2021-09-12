using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int Count = 0;
    private GameManager gameManager;
    bool selected = false;
    private float zBound = 2f;
    private float xBound = 2f;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if(selected)
            {
                gameManager.Add(10);
            } else
            {
                gameManager.Add(1);
            }
        }
    }

    public void toggle()
    {
        selected = true;
    }
}
