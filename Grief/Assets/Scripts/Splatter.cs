using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Splatter : MonoBehaviour
{
    [SerializeField]
    Color32 colorChoice;
    public List<Sprite> sprites; //ref to the sprites which will be used by sprites renderer
    public SpriteRenderer spriteRenderer;//ref to sprite renderer component
    [SerializeField]
    BoxCollider2D noFrictionFloorPrefab;
    [SerializeField]
    private float detectFloorRadius = 1.5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        
        ApplyStyle();
    }
    
    public void ApplyStyle()
    {
        spriteRenderer.color = colorChoice;
        transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
        ChangePhysicsMaterials();
    }

    private void ChangePhysicsMaterials() {
        Collider2D[] floorColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), detectFloorRadius);
        foreach (var coll in floorColliders)
        {
            if(coll.gameObject.tag == "PaintableSurfaceTag")
                coll.sharedMaterial = noFrictionFloorPrefab.sharedMaterial;
        }
    }
}
