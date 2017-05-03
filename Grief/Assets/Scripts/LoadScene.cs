using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    [SerializeField]
    string sceneToLoad;

    public void LoadFirstLevel(string s)
    {
        SceneManager.LoadScene(s);
    }
}
