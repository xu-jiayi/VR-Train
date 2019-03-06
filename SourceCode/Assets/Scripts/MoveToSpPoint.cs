using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSpPoint : MonoBehaviour {

    public float targetPositionX;
    public float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x < targetPositionX)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * -1);
        }
	}
}
