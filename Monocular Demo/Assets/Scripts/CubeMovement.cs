using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementAxis
{
    X,
    Y,
    Z,
    None
}
public class CubeMovement : MonoBehaviour
{
    [SerializeField] MovementAxis movementAxis;
    [SerializeField] float speed = 1f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (movementAxis)
        {
            case MovementAxis.X:
                transform.position = new Vector3(initialPosition.x + Mathf.Sin(speed * Time.time), transform.position.y, transform.position.z);
                break;

            case MovementAxis.Y:
                transform.position = new Vector3(transform.position.x, initialPosition.y + Mathf.Sin(speed * Time.time), transform.position.z);
                break;

            case MovementAxis.Z:
                transform.position = new Vector3(transform.position.x, transform.position.y, initialPosition.z + Mathf.Sin(speed * Time.time));
                break;

            case MovementAxis.None:
                break;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
