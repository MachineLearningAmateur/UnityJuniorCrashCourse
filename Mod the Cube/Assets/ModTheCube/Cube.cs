using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), 1);
        InvokeRepeating("Scale", 1.0f, 1.5f);
       
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime, 10.0f * Time.deltaTime);
    }

    void Scale()
    {
        Debug.Log("Hello");
        transform.localScale = Vector3.one * Random.Range(1.0f, 25.0f);
    }
}
