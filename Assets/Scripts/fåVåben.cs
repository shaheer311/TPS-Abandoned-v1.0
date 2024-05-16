using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fåVåben : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad; // Navnet på scenen, der skal indlæses

    void Update()
    {
        // Hent spillerens position
        Vector3 position = transform.position;

        // Tjek om spillerens X og Z positioner er inden for de nye specificerede intervaller
        if (position.x >= 2f && position.x <= 3f && position.z >= 26.5f && position.z <= 28.5f)
        {
            // Skift scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
