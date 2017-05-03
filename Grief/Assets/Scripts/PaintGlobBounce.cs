using UnityEngine;
using System.Collections;
using System;

public class PaintGlobBounce : MonoBehaviour {
    [SerializeField]
    SplatterBouncePaint splatterBounce;
    [SerializeField]
    float shotSpeed = 300;
    SplatterBouncePaint splatterBounceObj;
    PlayerController player;
    bool isFacingRight;
    private Vector3 lastSplatterLocation;
    SplatterBouncePaint newSplatterBounceObj;
    bool isDestroyed = false;
    [SerializeField]
    private float detectWallRadius = .5f;

    void Awake() {
        try { player = GameObject.Find("Player").GetComponent<PlayerController>(); }
        catch (Exception) { throw new Exception("Scene must include an object called \"Player\" with the playerController script attached"); }
        splatterBounceObj = Instantiate(splatterBounce, transform.position, Quaternion.identity) as SplatterBouncePaint;
        splatterBounceObj.transform.localScale = new Vector3(.5f, .5f, .5f);
        splatterBounceObj.transform.parent = transform;
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
                newSplatterBounceObj = Instantiate(splatterBounce, new Vector3(transform.position.x + (isFacingRight ? .5f : -.5f), transform.position.y - 1f, transform.position.z), Quaternion.identity) as SplatterBouncePaint;
                //newSplatterBounceObj.transform.localScale = new Vector3(.6f, .6f, .6f);
                lastSplatterLocation = transform.position;
                newSplatterBounceObj.ApplyStyle();
            }
            Collider2D[] wallColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), detectWallRadius);
            foreach (Collider2D coll in wallColliders)
                if (coll.gameObject.CompareTag("PaintableSurfaceTag"))
                {
                    //coll.sharedMaterial = bouncyFloorPrefab.sharedMaterial;
                    //Debug.Log("Should have worked....");
                    isDestroyed = true;
                }
            if (isDestroyed)
                SplatToWall();
        }
    }

    void SplatToWall() {
        SplatterBouncePaint splatterPaintToObj =
            (SplatterBouncePaint)Instantiate(splatterBounce,
            new Vector3(transform.position.x + (isFacingRight ? .5f : -.5f),
            transform.position.y, transform.position.z), Quaternion.identity);
        splatterPaintToObj.transform.localScale = new Vector3(.6f, .6f, .6f);
        splatterPaintToObj.ApplyStyle();
        splatterBounceObj.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Destroy(splatterBounceObj.gameObject.GetComponent<GameObject>());
        Destroy(gameObject.GetComponent<GameObject>());
    }
    //void OnCollisionStay2D(Collision2D coll) {
    //    if (coll.gameObject.CompareTag("PaintableSurfaceTag"))
    //    {

    //    }
    //}
}
