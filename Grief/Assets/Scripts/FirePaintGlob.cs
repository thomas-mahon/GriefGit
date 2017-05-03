using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePaintGlob : MonoBehaviour {

    [SerializeField]
    PaintGlobBounce paintGlobBounce;
    [SerializeField]
    PaintGlob paintGlob;
    [SerializeField]
    float shotOffset;
    [SerializeField]
    Image activeColorIndicator;
    [SerializeField]
    Color paintGreen;
    [SerializeField]
    Color paintRed;
    [SerializeField]
    Color paintBlue;
    [SerializeField]
    Color paintBlack;
    [SerializeField]
    Color paintYellow;

    enum ActiveColor {
    green, red, blue, black, yellow };
    ActiveColor activeColor = ActiveColor.green;


    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        activeColorIndicator.color = paintGreen;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateShooting();
        UpdateColor();
    }

    private void UpdateColor() {
        if (Input.GetButtonDown("SwapColor"))
        {
            switch (activeColor)
            {
                case ActiveColor.green:
                    //activeColor = ActiveColor.red;
                    //activeColorIndicator.color = paintRed;
                    activeColor = ActiveColor.blue;
                    activeColorIndicator.color = paintBlue;
                    break;
                //case ActiveColor.red:
                //    activeColor = ActiveColor.blue;
                //    activeColorIndicator.color = paintBlue;
                //    break;
                case ActiveColor.blue:
                    //activeColor = ActiveColor.black;
                    //activeColorIndicator.color = paintBlack;
                    activeColor = ActiveColor.green;
                    activeColorIndicator.color = paintGreen;
                    break;
                //case ActiveColor.black:
                //    activeColor = ActiveColor.yellow;
                //    activeColorIndicator.color = paintYellow;
                //    break;
                //case ActiveColor.yellow:
                //    activeColor = ActiveColor.green;
                //    activeColorIndicator.color = paintGreen;
                //    break;
                default:
                    break;
            }
        }
    }

    private void UpdateShooting() {
        if (Input.GetButtonDown("Fire1"))
            //FireBouncePaintGlob();
            switch (activeColor)
            {
                case ActiveColor.green:
                    Fire();
                    break;
                //case ActiveColor.red:
                //    FireDamagePaintGlob();
                    //break;
                case ActiveColor.blue:
                    FireBouncePaintGlob();
                    break;
                //case ActiveColor.black:
                //    FireFloorDeactivatePaintGlob();
                //    break;
                //case ActiveColor.yellow:
                //    FireWallDeactivatePaintGlob();
                //    break;
                default:
                    break;
            }
    }

    //private void FireWallDeactivatePaintGlob() {
    //    throw new NotImplementedException();
    //}

    //private void FireFloorDeactivatePaintGlob() {
    //    throw new NotImplementedException();
    //}

    //private void FireDamagePaintGlob() {
    //    throw new NotImplementedException();
    //}

    private void Fire() {
        Instantiate(paintGlob, new Vector3(transform.position.x + (spriteRenderer.flipX ? -1 : +1), transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void FireBouncePaintGlob() {
        Instantiate(paintGlobBounce, new Vector3(transform.position.x + (spriteRenderer.flipX ? -shotOffset : +shotOffset), transform.position.y, transform.position.z), Quaternion.identity);
    }

}
