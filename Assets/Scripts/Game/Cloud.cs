using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public AnimationCurve curve;

    float timer, baseY;

    public float speed;

	void Start ()
    {
        baseY = transform.position.y;

    }
	
	void FixedUpdate()
    {
        timer += speed * Time.deltaTime;
        
        if(timer >= 1)
        {
            timer = 0;
        }

        transform.position = new Vector3(transform.position.x - ((speed * 10) * Time.deltaTime), baseY + curve.Evaluate(timer) * 2, transform.position.z);

        if(transform.position.x < Camera.main.transform.position.x - 61f)
        {
            Destroy(gameObject);
        }
	}
}
