using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject stor; // Reference til det store objekt
    public GameObject lille; // Reference til det lille objekt

    private GameObject activeObject; // Det objekt, der aktuelt kontrolleres

    void Start()
    {
        // Start med at det store objekt er aktivt
        activeObject = stor;
    }

    void Update()
    {
        // Skift aktivt objekt når mellemrumstasten trykkes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (activeObject == stor)
                activeObject = lille;
            else
                activeObject = stor;
        }

        // Flyt det aktive objekt baseret på piletasterne
        float moveZ = Input.GetAxis("Vertical"); // Brug piletasterne op/ned
        activeObject.transform.Translate(0, 0, moveZ * Time.deltaTime);
    }
}
