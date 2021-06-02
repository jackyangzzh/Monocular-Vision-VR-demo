using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Change Sin function to the desire axis
        transform.position = new Vector3(Mathf.Sin(Time.time), 0, 0);
    }
}


