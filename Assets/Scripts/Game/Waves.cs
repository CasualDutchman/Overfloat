using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public AnimationCurve curve;

    public Transform rotator;

    [Range(0.0f, 10.0f)]
    public float valueOne = 0.7f;
    [Range(0, 50)]
    public float valueTwo = 20f;

    public float rotation = 0;

    float randomer = 1;

    public bool isOwnBoat;

	void Start ()
    {
        if(!isOwnBoat)
            randomer = Random.Range(0.4f, 0.6f);

    }
	
	void Update ()
    {
        rotation += (valueOne * randomer) * Time.deltaTime;

        if (rotation >= 1)
            rotation = 0;

        transform.eulerAngles = new Vector3(0, 0, -(valueTwo / 2) + (curve.Evaluate(rotation) * valueTwo));
        if ((!isOwnBoat && GetComponent<Enemy>() && GetComponent<Enemy>().Health > 0) || (GetComponent<Barrel>() && !GetComponent<Barrel>().taken) || (isOwnBoat && GetComponent<Ship>() && GetComponent<Ship>().Health > 0))
        {
            transform.position = new Vector3(transform.localPosition.x, -(rotator.parent.position.y) + rotator.position.y, transform.localPosition.z);
        }

    }
}
