using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum MovementAxis
{
    X,
    Y,
    Z,
    Static
}
public class CubeMovement : MonoBehaviour
{
    [Header("Left Cube")]
    [SerializeField] GameObject leftCube;
    [SerializeField] MovementAxis leftAxis;
    [SerializeField] float leftSpeed = 1f;

    [Header("Right Cube")]
    [SerializeField] GameObject rightCube;
    [SerializeField] MovementAxis rightAxis;
    [SerializeField] float rightSpeed = 1f;

    [Header("Display")]
    [SerializeField] TextMeshProUGUI currentMoving;
    [SerializeField] TextMeshProUGUI leftAxisText;
    [SerializeField] TextMeshProUGUI rightAxisText;

    private Vector3 initialPosition;
    private bool moveLeft;

    private void Start()
    {
        // Need to initiate one position becacuse they are in the same spot
        initialPosition = leftCube.transform.position;
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region Manage Cube Movement
        switch (leftAxis)
        {
            case MovementAxis.X:
                leftCube.transform.position = new Vector3(initialPosition.x + Mathf.Sin(leftSpeed * Time.time), leftCube.transform.position.y, leftCube.transform.position.z);
                break;

            case MovementAxis.Y:
                leftCube.transform.position = new Vector3(leftCube.transform.position.x, initialPosition.y + Mathf.Sin(leftSpeed * Time.time), leftCube.transform.position.z);
                break;

            case MovementAxis.Z:
                leftCube.transform.position = new Vector3(leftCube.transform.position.x, leftCube.transform.position.y, initialPosition.z + Mathf.Sin(leftSpeed * Time.time));
                break;

            case MovementAxis.Static:
                break;
        }

        switch (rightAxis)
        {
            case MovementAxis.X:
                rightCube.transform.position = new Vector3(initialPosition.x + Mathf.Sin(rightSpeed * Time.time), rightCube.transform.position.y, rightCube.transform.position.z);
                break;

            case MovementAxis.Y:
                rightCube.transform.position = new Vector3(rightCube.transform.position.x, initialPosition.y + Mathf.Sin(rightSpeed * Time.time), rightCube.transform.position.z);
                break;

            case MovementAxis.Z:
                rightCube.transform.position = new Vector3(rightCube.transform.position.x, rightCube.transform.position.y, initialPosition.z + Mathf.Sin(rightSpeed * Time.time));
                break;

            case MovementAxis.Static:
                break;
        }
        #endregion

        #region Manage Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            leftCube.transform.position = initialPosition;
            rightCube.transform.position = initialPosition;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (moveLeft)
            {
                leftAxis = MovementAxis.X;
            }
            else { rightAxis = MovementAxis.X; }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (moveLeft)
            {
                leftAxis = MovementAxis.Y;
            }
            else { rightAxis = MovementAxis.Y; }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (moveLeft)
            {
                leftAxis = MovementAxis.Z;
            }
            else { rightAxis = MovementAxis.Z; }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (moveLeft)
            {
                leftAxis = MovementAxis.Static;
            }
            else { rightAxis = MovementAxis.Static; }
        }
        #endregion

        #region Manage Display
        currentMoving.text = "Currently Selected: " + (moveLeft ? "Left" : "Right");
        leftAxisText.text = "Left: " + leftAxis;
        rightAxisText.text = "Right: " + rightAxis;
        #endregion


    }
}
