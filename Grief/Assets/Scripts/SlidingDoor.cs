using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class SlidingDoor : MonoBehaviour {
    
    [SerializeField]
    Key myKey;

    Key blankKey;
    Animator animator;
    bool isClosed;

    void Start() {
        try{ animator = GetComponent<Animator>(); }
        catch (System.Exception){ throw new System.Exception(string.Format("Door object must have Animator component")); }
        
        isClosed = true;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<PlayerController>() && isClosed && InventoryManager.Keys.Contains(myKey))
        {
            if (InventoryManager.Keys.Contains(myKey))
                OpenDoor(coll);
        }
    }

    private void OpenDoor(Collision2D coll) {
        animator.SetBool("isOpen", true);
        isClosed = false;
    }
    
}
