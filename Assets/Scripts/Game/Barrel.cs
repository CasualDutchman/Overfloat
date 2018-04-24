using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    public bool taken;

	void Start ()
    {
		
	}
	
	void FixedUpdate()
    {
        if(taken)
        {
            transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y - 0.05f, transform.position.z);
            if(transform.position.y <= -10f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
        }
	}
}
