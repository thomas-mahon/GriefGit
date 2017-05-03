using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour {

    [SerializeField]
    GameObject movementControlsPanel;
    [SerializeField]
    GameObject tutorialPaintingControlsPanel;
    [SerializeField]
    GameObject tutorialCheckpointPanel;
    [SerializeField]
    GameObject tutorialJumpPanel;
    [SerializeField]
    GameObject tutorialBouncePaintPanel;

    
    bool hasClosedInitialPanel;
    bool hasMovedOneDirection;
	// Use this for initialization
	void Awake () {
        movementControlsPanel.SetActive(true);
        hasClosedInitialPanel = false;
        hasMovedOneDirection = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasClosedInitialPanel)
            if (Input.GetAxisRaw("Horizontal") != 0f)
                StartCoroutine(ClosePanel(movementControlsPanel));
        
        
	}

    private IEnumerator ClosePanel(GameObject panel) {
        yield return new WaitForSeconds(2f);
        if (!hasClosedInitialPanel)
        {
            SetTrigger(1);
            hasClosedInitialPanel = true;
        }
        panel.SetActive(false);
    }
    public void SetTrigger(int triggerNumber) {
        switch (triggerNumber)
        {
            case 0:
                tutorialCheckpointPanel.SetActive(true);
                StartCoroutine(ClosePanel(tutorialCheckpointPanel));
                break;
            case 1:
                tutorialPaintingControlsPanel.SetActive(true);
                StartCoroutine(ClosePanel(tutorialPaintingControlsPanel));
                break;
            case 2:
                tutorialJumpPanel.SetActive(true);
                StartCoroutine(ClosePanel(tutorialJumpPanel));
                break;
            case 3:
                tutorialBouncePaintPanel.SetActive(true);
                StartCoroutine(ClosePanel(tutorialBouncePaintPanel));
                break;
            default:
                break;
        }
    }
}
