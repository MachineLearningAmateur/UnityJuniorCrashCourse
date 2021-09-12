using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    // Start is called before the first frame update
    private float zBound = 1.8f;
    private float xBound = 1.8f;
    private void Start()
    {
        Vector3 newPos = new Vector3(Random.Range(-zBound, zBound), 12, Random.Range(-xBound, xBound));
        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
