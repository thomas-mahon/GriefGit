using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Vector3 activatedScale;
    [SerializeField]
    Color activatedColor;

    SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            ActivateCheckpoint(player);
        }
    }
    // Use this for initialization
    void Start () {
        try
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        catch (System.Exception)
        {
            Debug.Log("Checkpoint Object must have a SpriteRenderer named \"spriteRenderer\"");
            throw;
        }
	}

    void ActivateCheckpoint(PlayerController player)
    {
        transform.localScale = activatedScale;
        spriteRenderer.color = activatedColor;
        player.LastCheckpoint = transform;
    }
}
