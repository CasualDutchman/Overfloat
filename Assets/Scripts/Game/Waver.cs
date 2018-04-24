using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waver : MonoBehaviour
{
    public Transform rotator;

    public float offset;

    float timer;

	void Start ()
    {
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(offset + rotator.position.x, rotator.position.y, transform.position.z);
    }
}
