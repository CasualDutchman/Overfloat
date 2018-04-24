using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject fadeIn, fadeOut;

    public void goToLevel(int id)
    {
        GetComponent<WorldManager>().ID = id;
        //GameObject.Find("FadePanel").GetComponent<FadeOut>().goFade = true;
        GameObject go = Instantiate(fadeOut, GameObject.Find("Canvas").transform) as GameObject;
        go.GetComponent<FadeOut>().goFade = true;

    }
}
