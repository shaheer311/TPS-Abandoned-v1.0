using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionBasedSceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Navnet på scenen, der skal indlæses

    void Update()
    {
        // Hent spillerens position
        Vector3 position = transform.position;

        // Tjek om spillerens X og Z positioner er inden for de specificerede intervaller
        if (position.x >= -67 && position.x <= -63 && position.z >= 22 && position.z <= 37)
        {
            // Skift scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
