using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [Range(1, 10)]
    public float speed = 1.0f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, speed * 30 * Time.deltaTime));
    }
}
