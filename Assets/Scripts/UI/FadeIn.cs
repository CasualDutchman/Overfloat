using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fader;
    float timer = 1f;

    public bool goFade = false;
    public bool isFaded = false;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (goFade)
        {
            GetComponent<RectTransform>().position = new Vector3(1920 / 2, 1080 / 2, 0);

            timer -= 0.05f;

            fader.color = new Color(0, 0, 0, timer);

            if (timer <= 0)
            {
                this.enabled = false;
                isFaded = true;
            }
        }
    }
}
