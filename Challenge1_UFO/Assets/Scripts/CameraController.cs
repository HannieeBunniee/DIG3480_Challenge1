using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public game object reference to the player
    public GameObject player;

    //private vector3 to hold offset value
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // make offset= transform position - player position ( make the camera follow the ufo/player)
        offset = transform.position - player.transform.position;

    }

    // LateUpdate make sure items have been processed in update while running
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
