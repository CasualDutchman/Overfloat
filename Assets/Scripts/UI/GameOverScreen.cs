using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public AnimationCurve curve;

    float timer, timer2, random, random2;
    public float offsetY, offsetX, MaxRand;

    void Start()
    {
        offsetY = transform.localPosition.y;
        offsetX = transform.localPosition.x;
        random = Random.Range(0.05f, 0.15f);
        random2 = Random.Range(0.05f, 0.15f);
    }

	void Update()
    {
        timer += random * Time.deltaTime;
        if (timer >= 1) { timer = 0; }

        timer2 += random2 * Time.deltaTime;
        if (timer2 >= 1) { timer2 = 0; }

        transform.localPosition = new Vector3(offsetX + (curve.Evaluate(timer2) / (MaxRand * 2f)), offsetY + (curve.Evaluate(timer) / MaxRand), transform.localPosition.z);
	}
}
