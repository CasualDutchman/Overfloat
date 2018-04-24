using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

    Animator anim;

    public float timer = 0, maxtimer = 5;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("play", true);
    }

    void FixedUpdate()
    {
        timer += 0.1f;
        if (timer >= maxtimer)
        {
            Destroy(gameObject);
        }

    }
}
