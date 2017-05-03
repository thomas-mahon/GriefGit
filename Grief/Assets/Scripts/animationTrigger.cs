using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTrigger : MonoBehaviour {
    [SerializeField]
    Animator targetCameraAnimator;
    [SerializeField]
    string animationTriggerName;

    bool hasRunAnimation = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player") && !hasRunAnimation)
        {
            targetCameraAnimator.enabled = true;
            targetCameraAnimator.gameObject.GetComponent<CameraAnimation>().enabled = true;
            targetCameraAnimator.SetTrigger(animationTriggerName);
            hasRunAnimation = true;
            gameObject.SetActive(false);
        }
    }
	
}
