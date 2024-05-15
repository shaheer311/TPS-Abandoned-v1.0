using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndDisplayAngle : MonoBehaviour
{
    public Transform ball; // Reference til kuglen
    public TMPro.TMP_Text angleText; // Reference til 3D tekstkomponenten
    public float forceMagnitude = 1000f; // Styrken af affyringskraften

    private float rotationAngle = 45f; // Startvinkel for skråt kast
    private Rigidbody ballRigidbody; // Rigidbody komponenten for kuglen
    private bool canShoot = true; // Flag til at kontrollere affyring

    void Start()
    {
        // Få reference til Rigidbody
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ændr rotation baseret på piletasterne
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotationAngle += 5f; // Øg rotationsvinklen
            if (rotationAngle > 90f) rotationAngle = 90f; // Begræns vinklen til 90 grader
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotationAngle -= 5f; // Reducer rotationsvinklen
            if (rotationAngle < 0f) rotationAngle = 0f; // Begræns vinklen til 0 grader
        }

        // Opdater 3D tekst for at vise den aktuelle vinkel
        angleText.text = "Vinkel: " + rotationAngle.ToString("F0") + "°";

        // Affyr kuglen med mellemrumstasten
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            FireCannon();
        }
    }

    void FireCannon()
    {
        // Beregn affyringsretning baseret på den aktuelle rotation
        Vector3 forceDirection = Quaternion.Euler(-rotationAngle, 0, 0) * Vector3.forward * forceMagnitude;
        // Tilføj en impuls til kuglens Rigidbody
        ballRigidbody.AddForce(forceDirection, ForceMode.Impulse);
        canShoot = false; // Forhindre gentagen affyring
    }
}
