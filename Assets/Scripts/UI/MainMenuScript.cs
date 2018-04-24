using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public AnimationCurve curve;

    public Button[] buttons, optionsButtons;
    public int currentHoverOver, currentOptionsOver;

    public RectTransform mainmenu, credits, options, optionsArrow, Splash;

    public RectTransform[] arrowPos, optionArrowPos;

    float timer, timer2;

    bool newState, optionsState;

    void Start ()
    {

    }

    void Update()
    {
        timer2 += 0.3f * Time.deltaTime;
        if(timer2 >= 1)
        {
            timer2 = 0;
        }

        Splash.eulerAngles = Vector3.forward * ((curve.Evaluate(timer2) - 0.5f) * 15);

        if (newState)
        {
            mainmenu.localScale = Vector3.zero;
            credits.localScale = Vector3.one;
            options.localScale = Vector3.zero;
        }
        else if(optionsState)
        {
            mainmenu.localScale = Vector3.zero;
            credits.localScale = Vector3.zero;
            options.localScale = Vector3.one;
        }
        else
        {
            mainmenu.localScale = Vector3.one;
            credits.localScale = Vector3.zero;
            options.localScale = Vector3.zero;
        }

        if (Input.GetButton("Jump") || Input.GetMouseButton(0))
        {
            timer += Time.deltaTime * 1.5f;
            transform.GetComponent<Image>().fillAmount = 1 - (timer / 1f);
            optionsArrow.GetComponent<Image>().fillAmount = 1 - (timer / 1f);

        }
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0))
        {
            if (!newState && !optionsState) // ======
            {
                if (timer < 1f)
                {
                    currentHoverOver++;
                    if (currentHoverOver > buttons.Length - 1)
                    {
                        currentHoverOver = 0;
                    }
                    //transform.GetComponent<RectTransform>().localPosition = new Vector3(327f, 928f - (currentHoverOver * 170), 0);
                    transform.GetComponent<RectTransform>().position = arrowPos[currentHoverOver].position;
                    timer = 0;
                }
                else if (timer >= 1f)
                {
                    if (currentHoverOver == 0)
                    {
                        GameObject.FindGameObjectWithTag("Manager").GetComponent<ButtonPress>().goToLevel(2);
                    }
                    else if (currentHoverOver == 1)
                    {
                        optionsState = true;
                    }
                    else if (currentHoverOver == 2)
                    {
                        newState = true;
                    }
                    else if (currentHoverOver == 3)
                    {
                        Application.Quit();
                    }
                    timer = 0;
                }
                transform.GetComponent<Image>().fillAmount = 1;
                optionsArrow.GetComponent<Image>().fillAmount = 1;
            }
            else if(optionsState && !newState) //========
            {
                if (timer < 1f)
                {
                    currentOptionsOver++;
                    if (currentOptionsOver > optionsButtons.Length - 1)
                    {
                        currentOptionsOver = 0;
                    }
                    //optionsArrow.position = new Vector3(327f, 928f - (currentOptionsOver * 170), 0);
                    optionsArrow.position = optionArrowPos[currentOptionsOver].position;
                    timer = 0;
                }
                else if (timer >= 1f)
                {
                    if (currentOptionsOver == 0)
                    {
                        //TODO
                    }
                    else if (currentOptionsOver == 1)
                    {
                        //TODO
                    }
                    else if (currentOptionsOver == 2)
                    {
                        optionsState = false;
                    }
                    timer = 0;
                }
                optionsArrow.GetComponent<Image>().fillAmount = 1;
                transform.GetComponent<Image>().fillAmount = 1;
            }
            else if(!optionsState && newState)// ======
            {
                newState = false;
                timer = 0;
            }
        }
    }
}
