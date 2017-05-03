using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
    [SerializeField]
    float damage;
	
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.GetComponent<PlayerController>())
            coll.GetComponent<PlayerController>().SendMessage("ApplyDamage");
    }
}
