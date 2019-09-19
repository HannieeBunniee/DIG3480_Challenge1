using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    void Update()
    {
        //making the gold rotate in Z axis
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
