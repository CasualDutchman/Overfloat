using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform hand;

    float timer;

	void Start () {
		
	}
	
	void Update()
    {
        timer += 0.4f * Time.deltaTime;
        if (timer >= 1) { timer = 0; }

        hand.localEulerAngles = new Vector3(0,0, -30 + (curve.Evaluate(timer) * 50));
	}
}
