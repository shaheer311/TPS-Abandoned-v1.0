using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class CubeBalanceGame : MonoBehaviour
{
    public Transform cube;  // Reference to the cube
    public TextMeshProUGUI popupText;  // Reference to the popup Text Mesh Pro UI

    private float stableTimeRequired = 3.0f;  // Time required to maintain balance
    private float stableTimer = 0;  // Timer to track how long the cube has been stable

    void Start()
    {
        popupText.gameObject.SetActive(false);  // Ensure the popup is hidden initially
    }

    void Update()
    {
        // Check if the cube's rotation on the X-axis is within the desired range
        float xRotation = Mathf.Abs(cube.eulerAngles.x);
        if (xRotation <= 2.0f || xRotation >= 358.0f)  // Adjust for the rotation values as Euler angles loop from 0 to 360
        {
            stableTimer += Time.deltaTime;  // Increment the timer if the cube is in the balance range
            if (stableTimer >= stableTimeRequired)  // Check if it has been stable for the required time
            {
                if (!popupText.gameObject.activeInHierarchy)
                {
                    popupText.gameObject.SetActive(true);
                    popupText.text = "Du har fundet den rette balance mellem vægt og afstand for at balancere pladen.";
                }
            }
        }
        else
        {
            stableTimer = 0;  // Reset the timer if the cube moves out of the balance range
        }
    }
}
