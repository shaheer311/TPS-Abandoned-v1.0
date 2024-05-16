using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for Scene Management
using TMPro;  // Ensure TMPro is included if you're using Text Mesh Pro for popups

public class RotateAndDisplayAngle : MonoBehaviour
{
    public Transform ball; // Reference to the ball
    public TMPro.TMP_Text angleText; // Reference to the 3D text component
    public float forceMagnitude = 1000f; // Strength of firing force
    public GameObject popup; // Reference to the popup message object
    public string sceneToLoad; // Navnet på scenen, der skal indlæses

    private float rotationAngle = 0f; // Starting angle for the projectile
    private Rigidbody ballRigidbody; // Rigidbody component for the ball
    private bool canShoot = true; // Control flag for firing
    private float launchTime; // Time at which the ball was fired
    private bool isBallLaunched; // Check if the ball has been launched

    void Start()
    {
        ballRigidbody = ball.GetComponent<Rigidbody>();
        popup.SetActive(false); // Ensure the popup is disabled at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotationAngle += 5f;
            if (rotationAngle > 90f) rotationAngle = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotationAngle -= 5f;
            if (rotationAngle < 0f) rotationAngle = 0f;
        }

        angleText.text = "Angle: " + rotationAngle.ToString("F0") + "°";

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            FireCannon();
        }

        if (isBallLaunched)
        {
            if (Time.time - launchTime > 4f && ball.position.z < 4.215)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset scene
            }
            else if (ball.position.z >= 4.215)
            {
                if (!popup.activeInHierarchy)
                {
                    popup.SetActive(true);
                    popup.GetComponent<TMP_Text>().text = "Du har mestret den perfekte vinkel. Sejren er din.";
                    StartCoroutine(WaitAndLoadScene(4.0f));  // Start coroutine to wait and load scene
                    isBallLaunched = false; // Stop checking after displaying the popup
                }
            }
        }
    }

    void FireCannon()
    {
        Vector3 forceDirection = Quaternion.Euler(-rotationAngle, 0, 0) * Vector3.forward * forceMagnitude;
        ballRigidbody.AddForce(forceDirection, ForceMode.Impulse);
        canShoot = false;
        launchTime = Time.time;
        isBallLaunched = true;
    }

    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneToLoad);
    }
}
