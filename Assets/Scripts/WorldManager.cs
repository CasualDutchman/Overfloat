using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{

    public int ID;

    GameObject[] managers;

    void Start ()
    {
        managers = GameObject.FindGameObjectsWithTag("Manager");

        if (managers.Length > 1)
        {
            for(int i = 0; i < managers.Length - 1; i++)
            {
                Destroy(managers[i + 1]);
            }
        }

        DontDestroyOnLoad(gameObject);

	}
	
	void FixedUpdate()
    {
        if (GameObject.Find("FadePanel(Clone)"))
        {
            if (GameObject.Find("FadePanel(Clone)").GetComponent<FadeOut>())
            {
                if (GameObject.Find("FadePanel(Clone)").GetComponent<FadeOut>().isFaded)
                {
                     SceneManager.LoadScene(ID);
                }
            }

            if (GameObject.Find("FadePanel(Clone)").GetComponent<FadeIn>())
            {
                if (GameObject.Find("FadePanel(Clone)").GetComponent<FadeIn>().isFaded)
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }

        transform.position = Camera.main.transform.position;
    }
}
