using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    AudioSource audio;
    AudioSource audioshoot;
    GameObject player;

    public GameObject bullet, barrel, explosion, explosionBig;
    public Transform rotator;

    public bool Suicide;
    public float Health = 100, maxHealth = 100, speed = 10;

    public Color[] hpColors;

    public bool hitBoat;

    float timer,timer2;

    Image healthBar;
    Transform doe;

    void Start()
    {
        player = GameObject.Find("Boat");
        healthBar = transform.Find("DO").GetChild(0).GetChild(0).GetComponent<Image>();
        rotator = GetComponent<Waves>().rotator;
        doe = transform.Find("DO");
        Health = maxHealth;
        audio = GetComponent<AudioSource>();
        audioshoot = GetComponentsInChildren<AudioSource>()[1];
    }
	
    void FixedUpdate()
    {
        healthBar.fillAmount = (Health / maxHealth);
        healthBar.color = hpColors[Mathf.FloorToInt(Health / maxHealth * 4)];

        transform.position = new Vector3(transform.position.x - (0.01f * speed), transform.position.y, transform.position.z);
        
        doe.localEulerAngles = new Vector3(0, 0, -transform.localEulerAngles.z);

        if(maxHealth >= 80)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 15 && Health > 0)
            {
                audioshoot.volume = 0.8f;
                audioshoot.Play();
                GameObject GO = Instantiate(bullet, transform.Find("BulletHole").position, bullet.transform.rotation) as GameObject;
                GO.GetComponent<Bullet>().shooter = 1;
                Rigidbody r = GO.GetComponent<Rigidbody>();
                r.AddForce(transform.Find("BulletHole").up * (1400));
                timer2 = 0;
            }
        }

        if (Health <= 0)
        {
            timer += 0.1f * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + (timer), transform.position.y - timer, transform.position.z);
        }

        if(Suicide && player != null && transform.position.x <= player.transform.position.x && Health > 0)
        {
            Instantiate(explosionBig, transform.position, Quaternion.identity);
            player.GetComponent<Ship>().Move();
            player.GetComponent<Ship>().Health -= 20;
            player.GetComponent<Ship>().destroylastIcons(2);
            Destroy(gameObject);
        }

        if(player != null && transform.position.x < player.transform.position.x - 3 && !hitBoat && Health > 0)
        {
            player.GetComponent<Ship>().Health -= 10;
            player.GetComponent<Ship>().destroylastIcons(1);
            player.GetComponent<Ship>().Move();
            hitBoat = true;
            audio.pitch = Random.Range(1.00f, 1.50f);
            audio.volume = Random.Range(0.80f, 1.20f);
            audio.Play();
            //Destroy(gameObject);
        }

        if (transform.position.y <= -10 || transform.position.x < Camera.main.transform.position.x - 40)
        {
            if (maxHealth >= 200)
            {
                GameObject.Find("Canvas").transform.Find("FadePanel in").GetComponent<FadeOut>().goFade = true;
                if (GameObject.Find("Canvas").transform.Find("FadePanel in").GetComponent<FadeOut>().isFaded)
                {
                    SceneManager.LoadScene(4);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Bullet>() && Health > 0)
        {
            Health -= col.gameObject.GetComponent<Bullet>().damage;
            audio.pitch = Random.Range(1.00f, 1.50f);
            audio.volume = Random.Range(0.80f, 1.20f);
            audio.Play();

            Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);

            if (Health <= 0)
            {
                if(maxHealth >= 200)
                {
                    player.GetComponent<Ship>().killedBoss = true;
                }
                if (barrel != null)
                {
                    GameObject GO = Instantiate(barrel, transform.position - new Vector3(0, 0.2f, 0), barrel.transform.rotation) as GameObject;
                    GO.GetComponent<Waves>().rotator = rotator;
                }
                player.GetComponent<Ship>().Move();
            }

            Destroy(col.gameObject);
        }
    }
}
