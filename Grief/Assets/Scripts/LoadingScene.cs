﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    [SerializeField]
    Slider progressSlider;
    [SerializeField]
    public string sceneToOpen;


    private const string loadingSceneName = "LoadingScene";

	// Use this for initialization
	void Start () {
        progressSlider.value = 0;
        StartCoroutine(BeginLoading());
	}
	
    public static void LoadNewScene(string sceneToLoad)
    {
        SceneManager.LoadScene(loadingSceneName);
    }

    
    private IEnumerator BeginLoading()
    {

        yield return new WaitForSeconds(0.5f);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneToOpen, LoadSceneMode.Additive);

        while (!async.isDone)
        {
            progressSlider.value = async.progress;
            yield return null;
        }
        
        progressSlider.value = 1;
        SceneManager.UnloadSceneAsync(loadingSceneName);
    }
}
