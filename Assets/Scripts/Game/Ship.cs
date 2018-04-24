using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    AudioSource engine;
    public AudioClip[] sounds;

    AudioSource audio;

    public int Health = 50;

    public GameObject[] enemies;
    public GameObject boss;

    public GameObject enemy, cameraRig, UiElement, scorePanel, explosion;

    public Transform rotator;

    public Animator anim;

    public bool killedBoss;

    bool move;
    int timer, random;
    float timer2;

    public int points;

	void Start ()
    {
        anim = transform.Find("wheel").GetComponent<Animator>();
        engine = GetComponentsInChildren<AudioSource>()[1];
        audio = GetComponentsInChildren<AudioSource>()[2];
        Move();
    }
	
	void FixedUpdate()
    {
		if(move)
        {
            timer++;
            transform.position = new Vector3(transform.position.x + 0.1f, 0, 31);
            cameraRig.transform.position = transform.position;

            if (timer >= 100 + random)
            {
                move = false;
                anim.SetBool("isGoing", false);
                engine.clip = sounds[0];
                engine.Play();
                timer = 0;
            }
        }

        if (Health <= 0)
        {
            timer2 += 0.0005f;
            transform.position = new Vector3(transform.position.x + (timer2), transform.position.y - timer2, transform.position.z);
            if (transform.position.y <= -9)
            {
                GameObject.Find("Canvas").transform.Find("FadePanel in").GetComponent<FadeOut>().goFade = true;
                if (GameObject.Find("Canvas").transform.Find("FadePanel in").GetComponent<FadeOut>().isFaded)
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }

    public void Move()
    {
        if (!killedBoss || Health < 0)
        {
            GameObject newSpawn = enemies[Random.Range(0, enemies.Length)];
            if (points >= 100)
            {
                newSpawn = boss;
            }
            GameObject GO = Instantiate(newSpawn, new Vector3(transform.position.x + 60, 0, 31), Quaternion.identity) as GameObject;
            GO.GetComponent<Waves>().rotator = rotator;
            random = Random.Range(0, 10);
            engine.clip = sounds[1];
            engine.Play();
            move = true;
            anim.SetBool("isGoing", true);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Bullet>() && col.gameObject.GetComponent<Bullet>().shooter != 0 && Health > 0)
        {
            Health -= 10;

            audio.pitch = Random.Range(1.00f, 1.50f);
            audio.volume = Random.Range(0.80f, 1.20f);
            audio.Play();

            Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);

            destroylastIcons(1);

            Destroy(col.gameObject);
        }
        if (col.gameObject.GetComponent<Barrel>())
        {
            points += 10;
            col.gameObject.GetComponent<Barrel>().taken = true;
            scorePanel.transform.Find("Text").GetComponent<Text>().text = "x" + Mathf.FloorToInt(points / 10);
        }
    }

    public void destroylastIcons(int j)
    {
        for(int i = 0; i < j; i++)
        {
            if(Health <= 10 && j == 2 && i == 1)
            {
                i = 0;
            }
            Destroy(UiElement.transform.GetChild(UiElement.transform.childCount - i - 1).gameObject);
        }
    }
}
