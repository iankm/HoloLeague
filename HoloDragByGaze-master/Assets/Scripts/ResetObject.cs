using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour {

    [SerializeField]
    float forwardDistance = 3.0f;

    [SerializeField]
    float upwardDistance = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
    public void ResetPosition()
    {
        gameObject.transform.position = 
            Camera.main.transform.position + 
            (Camera.main.transform.up * upwardDistance) +
            (Camera.main.transform.forward * forwardDistance);

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        gameObject.GetComponent<Rigidbody>().rotation = Quaternion.identity;
    }
}
