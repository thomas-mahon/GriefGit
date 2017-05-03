using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour {

    [SerializeField]
    string sceneToLoad;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
