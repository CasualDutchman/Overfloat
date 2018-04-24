using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    AudioSource audio;
    public GameObject bullet;

    public AnimationCurve curve;

    float timer;
    float powerup;

    public Image chargeUp;

    void Start ()
    {
        audio = GetComponentsInChildren<AudioSource>()[0];

    }
	
    void Update()
    {
        if(Input.GetButton("Jump") || Input.GetMouseButton(0))
        {
            timer += 0.01f;
            if (timer >= 1)
            {
                timer = 0;
            }
            powerup = curve.Evaluate(timer);
            chargeUp.fillAmount = powerup;
        }

        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0))
        {
            timer = 0;
            audio.pitch = powerup + 0.3f;
            audio.volume = (powerup * 0.8f) + 0.3f;
            audio.Play();
            GameObject GO = Instantiate(bullet, transform.Find("BulletHole").position, bullet.transform.rotation) as GameObject;
            GO.GetComponent<Bullet>().shooter = 0;
            Rigidbody r = GO.GetComponent<Rigidbody>();
            r.AddForce(transform.Find("BulletHole").up * (1600 * powerup));
            powerup = 0;
        }

        chargeUp.fillAmount = powerup;
    }
}
