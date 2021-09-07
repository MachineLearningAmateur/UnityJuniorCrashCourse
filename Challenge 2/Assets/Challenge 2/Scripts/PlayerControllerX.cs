using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool spawn = true;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spawn)
        {
            spawn = false;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            Invoke("Toggle", .5f);
        }
    }

    void Toggle()
    {
        spawn = true;
    }
}
