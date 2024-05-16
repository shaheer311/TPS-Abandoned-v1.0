using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skift2 : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad; // Navnet på scenen, der skal indlæses

    void Update()
    {
        // Hent spillerens position
        Vector3 position = transform.position;

        // Tjek om spillerens X og Z positioner er inden for de nye specificerede intervaller
        if (position.x >= -12f && position.x <= -9.5f && position.z >= -32f && position.z <= -28.5f)
        {
            // Skift scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
