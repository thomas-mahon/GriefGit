using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuOnEscape : MonoBehaviour {
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    GameObject menuPanel;
	// Use this for initialization
	void Start () {
        try { playerController = GameObject.Find("Player").GetComponent<PlayerController>(); }
        catch (System.Exception) { throw new System.Exception("Scene must contain a Player object"); }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuPanel.gameObject.activeSelf)
            {
                playerController.enabled = true;
                menuPanel.gameObject.SetActive(false);
            }
            else
            {
                playerController.enabled = false;
                menuPanel.gameObject.SetActive(true);
            }
        }
	}
}
