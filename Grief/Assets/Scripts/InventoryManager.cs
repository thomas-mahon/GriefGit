using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public static List<Key> Keys = new List<Key>();

    
    static GameObject greenKeyIndicator;
    static GameObject redKeyIndicator;
    static GameObject blueKeyIndicator;

    private void Start() {
        greenKeyIndicator = GameObject.Find("GreenKeyIndicator");
        redKeyIndicator = GameObject.Find("RedKeyIndicator");
        blueKeyIndicator = GameObject.Find("BlueKeyIndicator");

        greenKeyIndicator.SetActive(false);
        redKeyIndicator.SetActive(false);
        blueKeyIndicator.SetActive(false);
    }
    public static void AddKey(Key k) {
        Keys.Add(k);
        switch (k.keyName)
        {
            case "GreenKey":
                greenKeyIndicator.SetActive(true);
                break;
            case "RedKey":
                redKeyIndicator.SetActive(true);
                break;
            case "BlueKey":
                blueKeyIndicator.SetActive(true);
                break;
            default:
                break;
        }
    }
}
