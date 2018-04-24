using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeShown : MonoBehaviour {

    public GameObject fader;
    public float timerr, maxtime;

    void Start ()
    {
		
	}
	
	void Update()
    {
        timerr += Time.deltaTime;

        if (timerr >= maxtime || Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            fader.GetComponent<FadeOut>().goFade = true;
        }

        if (fader.GetComponent<FadeOut>().isFaded)
        {
            SceneManager.LoadScene(0);
        }
    }
}
