using UnityEngine;
using System.Collections;
using System;

public class PaintGlob : MonoBehaviour {
    [SerializeField]
    Splatter splatter;
    [SerializeField]
    float shotSpeed = 300;
    Splatter splatterObj;
    PlayerController player;
    bool isFacingRight;
    private Vector3 lastSplatterLocation;
    Splatter newSplatterObj;
    bool isDestroyed = false;
    [SerializeField]
    private float detectWallRadius = .5f;
    
    void Awake() {
        try { player = GameObject.Find("Player").GetComponent<PlayerController>(); }
        catch (Exception) { throw new Exception("Scene must include an object called \"Player\" with the playerController script attached"); }
        splatterObj = Instantiate(splatter, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity) as Splatter;
        splatterObj.transform.localScale = new Vector3(.5f, .5f, .5f);
        splatterObj.transform.parent = transform;
        isFacingRight = !player.SpriteRenderer.flipX;
        lastSplatterLocation = transform.position;
        StartCoroutine(DestroySelfInTime());
    }

    private IEnumerator DestroySelfInTime() {
        yield return new WaitForSeconds(.5f);
        SplatToWall();
    }

    void Update() {
        if (!isDestroyed)
        {
            if (isFacingRight)
                transform.position = new Vector3(transform.position.x + (shotSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x - (shotSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            if (Math.Abs(lastSplatterLocation.x - transform.position.x) >= 1)
            {
                newSplatterObj = Instantiate(splatter, new Vector3(transform.position.x + (isFacingRight ? .5f : -.5f), transform.position.y - 1f, transform.position.z), Quaternion.identity) as Splatter;
                //newSplatterObj.transform.localScale = new Vector3(.6f, .6f, .6f);
                lastSplatterLocation = transform.position;
                newSplatterObj.ApplyStyle();
            }
            Collider2D[] wallColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), detectWallRadius);
            foreach (Collider2D coll in wallColliders)
                if (coll.gameObject.CompareTag("PaintableSurfaceTag"))
                {
                    isDestroyed = true;
                }
            if (isDestroyed)
                SplatToWall();
        }
    }

    void SplatToWall() {
        Splatter splatterToObj = 
            (Splatter)Instantiate(splatter, 
            new Vector3(transform.position.x + (isFacingRight ? .5f : -.5f), 
            transform.position.y, transform.position.z), Quaternion.identity);
        //splatterToObj.transform.localScale = new Vector3(.6f, .6f, .6f);
        splatterToObj.ApplyStyle();
        splatterObj.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Destroy(splatterObj.gameObject.GetComponent<GameObject>());
        Destroy(gameObject.GetComponent<GameObject>());
    }
}
