using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    AudioSource audio;
    bool played;

    public GameObject splash;

    public int shooter;

    public int damage = 100;

	void Start ()
    {
        audio = GetComponent<AudioSource>();
	}
	
	void FixedUpdate()
    {
        if(transform.position.y <= -0.5f && !played)
        {
            Instantiate(splash, transform.position + (Vector3.up * 2), Quaternion.identity);

            audio.pitch = Random.Range(0.90f, 1.20f);
            audio.Play();
            played = true;
        }
		if(transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
	}
}
