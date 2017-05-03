using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonRespawnDebugging : MonoBehaviour {
    PlayerController playerController;
    Button button;
	// Use this for initialization
	void Start () {
        try{ playerController = GameObject.Find("Player").GetComponent<PlayerController>(); }
        catch (System.Exception) { throw new System.Exception("Scene must contain an object called \"Player\" with the playerController script attached."); }
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonDown);
	}
    void OnButtonDown() {
        playerController.SendMessage("Respawn");
    }
}
