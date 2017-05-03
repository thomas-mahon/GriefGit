using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour {
    
    public string keyName;
    
    public void DoActivate()
    {
        InventoryManager.AddKey(this);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<PlayerController>())
            DoActivate();
    }
    
    
}
