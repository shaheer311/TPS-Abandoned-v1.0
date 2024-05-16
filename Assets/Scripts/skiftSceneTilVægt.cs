using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad; // Navnet på scenen, der skal indlæses

    void Update()
    {
        // Hent spillerens position
        Vector3 position = transform.position;

        // Tjek om spillerens X og Z positioner er inden for de nye specificerede intervaller
        if (position.x >= -9 && position.x <= -8.3 && position.z >= 44.5 && position.z <= 46.5)
        {
            // Skift scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
