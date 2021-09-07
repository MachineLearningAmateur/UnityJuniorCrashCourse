using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 4, -8); //new Vector3 is used to create a Vector3 variable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() //will update after the Update method of the Player Controller happens
    {
        //Offset the camera behind the player by adding to the player's position with a new Vector3
        transform.position = player.transform.position + offset;
    }
}
