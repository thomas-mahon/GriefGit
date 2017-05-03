using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;

    int audioClipIndex = 0;
    void Update() {
        if (!audioSource.isPlaying && audioClipIndex != 2)
        {
            audioSource.clip = audioClips[++audioClipIndex];
            audioSource.Play();
        }
            
        if (!audioSource.isPlaying && audioClipIndex == 2)
            audioClipIndex = -1;
    }
}
