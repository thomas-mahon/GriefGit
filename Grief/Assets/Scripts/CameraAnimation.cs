using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {
    PlayerController playerController;
    bool isBeingAnimated;

    void Start() {
        try { playerController = GameObject.Find("Player").GetComponent<PlayerController>(); }
        catch (System.Exception) { throw new System.Exception("Scene must contain an object called 'Player' with the playerController script attached."); }
        IsBeingAnimated = false;
    }

    public bool IsBeingAnimated
    {
        get
        {
            return isBeingAnimated;
        }
        set
        {
            isBeingAnimated = value;
            playerController.enabled = !isBeingAnimated;
            GetComponent<Animator>().enabled = isBeingAnimated;
        }
    }
	// Update is called once per frame
	void Update () {
        if (IsBeingAnimated != GetComponent<CameraBehavior>().IsBeingAnimated)
            IsBeingAnimated = GetComponent<CameraBehavior>().IsBeingAnimated;
	}
}
