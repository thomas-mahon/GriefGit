using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    [SerializeField]
    GameObject objectToFollow;
    
    public bool IsBeingAnimated;

    Vector3 cameraOffset = new Vector3();


	// Use this for initialization
	void Start () {
        cameraOffset = new Vector3(2,1,transform.position.z);
        IsBeingAnimated = false;
        if(GetComponent<CameraAnimation>())
            GetComponent<CameraAnimation>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsBeingAnimated)
            this.transform.position = objectToFollow.transform.position + cameraOffset;
	}
    
}
