using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour {
    [SerializeField]
    int triggerNumber;

    TutorialPanel tutorialManager;
    bool hasTriggered;
    private void Awake() {
        tutorialManager = GameObject.Find("TutorialHintsPanel").GetComponent<TutorialPanel>();
        hasTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" && !hasTriggered)
        {
            tutorialManager.SetTrigger(triggerNumber);
            hasTriggered = true;
        }
    }
}
