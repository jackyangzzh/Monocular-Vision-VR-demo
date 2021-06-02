using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageController : MonoBehaviour
{
    [Header("Image Parameters")]
    [SerializeField] int upperBound = 250;
    [SerializeField] int lowerBound = 0;

    [Header("Image References")]
    [SerializeField] TextMeshProUGUI currentShift;
    [SerializeField] TextMeshProUGUI leftShift;
    [SerializeField] TextMeshProUGUI rightShift;
    [SerializeField] RawImage leftImage;
    [SerializeField] RawImage rightImage;

    private bool shiftLeft;
    private int leftShiftWavelength = 0, rightShiftWavelength = 0;

    void Awake()
    {
        shiftLeft = true;
    }

    void Update()
    {
        // Setting Display Images 
        leftImage.texture = Resources.Load("Images/" + leftShiftWavelength) as Texture;
        rightImage.texture = Resources.Load("Images/" + rightShiftWavelength) as Texture;
        currentShift.text = "Currently Shifting: " + (shiftLeft ? "Left" : "Right");
        leftShift.text = "Left Shift: " + leftShiftWavelength.ToString() + "nm";
        rightShift.text = "Right Shift: " + rightShiftWavelength.ToString() + "nm";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shiftLeft = !shiftLeft;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (shiftLeft)
            {
                if (leftShiftWavelength > lowerBound)
                {
                    leftShiftWavelength -= 25;
                }
            }
            else
            {
                if (rightShiftWavelength > lowerBound)
                {
                    rightShiftWavelength -= 25;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (shiftLeft)
            {
                if (leftShiftWavelength < upperBound)
                {
                    leftShiftWavelength += 25;
                }
            }
            else
            {
                if (rightShiftWavelength < upperBound)
                {
                    rightShiftWavelength += 25;
                }
            }
        }

    }
}
