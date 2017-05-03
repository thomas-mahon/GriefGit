using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {
    [SerializeField]
    float damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyDamage", damage);
            
        }
    }
}
