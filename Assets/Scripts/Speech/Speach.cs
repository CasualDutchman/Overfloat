using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Speach : MonoBehaviour
{
    public AnimationCurve curve;

    public Transform speechbubble, man1, man2;

    public FadeOut Fout;

    public int newer, conversation;
    float timer;

    public Image white;
    public Text name, intro;
    public Text[] text;
    public bool[] talking;
    public float[] intensifies;

    void Start ()
    {
        //text[0].enabled = true;
    }
	
	void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            if (conversation == 0)
            {
                conversation = 1;
                timer = 1;
            }
            else if (conversation == 2)
            {
                newer++;
                timer = 0;
                if (newer < text.Length)
                {
                    speechbubble.localScale = new Vector3(talking[newer] ? 3.6f : -3.6f, 1, -0.9f);
                    name.text = talking[newer] ? "Sam of the Tuna" : "Floyd Pink";
                }
                else
                {
                    conversation = 3;
                }
            }
            else if (conversation == 3)
            {
                Fout.goFade = true;
            }
        }

        if (conversation == 1)
        {
            
            if(man1.localPosition.x < -3)
            {
                timer -= Time.deltaTime * 2;
                man1.localPosition = new Vector3(man1.localPosition.x + 0.1f, man1.localPosition.y, man1.localPosition.z);
                man2.localPosition = new Vector3(man2.localPosition.x - 0.1f, man2.localPosition.y, man2.localPosition.z);

                speechbubble.position = new Vector3(speechbubble.position.x, speechbubble.position.y - 0.35f, speechbubble.position.z);
                intro.color = new Color(0.21f, 0.21f, 0.21f, timer);
                white.color = new Color(1, 1, 1, timer);
            }
            else
            {
                conversation = 2;
            }
        }
        else if (conversation == 2)
        {
            man1.localPosition = new Vector3(-3, man1.localPosition.y, man1.localPosition.z);
            man2.localPosition = new Vector3(3, man2.localPosition.y, man2.localPosition.z);
            speechbubble.position = new Vector3(speechbubble.position.x, 9.1f, speechbubble.position.z);

            name.enabled = true;

            if(newer >= 9)
            {
                man1.localScale = new Vector3(0.3333333f, 1, -0.5f);
            }

            if (newer < text.Length)
            {
                timer += (0.6f + intensifies[newer]) * Time.deltaTime;
                if (timer >= 1) { timer = 0; }

                if (talking[newer])
                {
                    man2.localPosition = new Vector3(man2.localPosition.x, man2.localPosition.y, -1.5f + curve.Evaluate(timer) * 0.1f);
                    man1.localPosition = new Vector3(man1.localPosition.x, man1.localPosition.y, -1.5f);
                }
                else
                {
                    man1.localPosition = new Vector3(man1.localPosition.x, man1.localPosition.y, -1.5f + curve.Evaluate(timer) * 0.1f);
                    man2.localPosition = new Vector3(man2.localPosition.x, man2.localPosition.y, -1.5f);
                }

                for (int i = 0; i < text.Length; i++)
                {
                    text[i].enabled = newer == i;

                }
            }
        }
        else if(conversation == 3)
        {
            man1.localScale = new Vector3(0.3333333f, 1, -0.5f);
            man2.localScale = new Vector3(-0.3333333f, 1, -0.5f);

            if (man1.localPosition.x > -6.7)
            {
                man1.localPosition = new Vector3(man1.localPosition.x - 0.1f, man1.localPosition.y, man1.localPosition.z);
                man2.localPosition = new Vector3(man2.localPosition.x + 0.1f, man2.localPosition.y, man2.localPosition.z);

                speechbubble.position = new Vector3(speechbubble.position.x, speechbubble.position.y + 0.35f, speechbubble.position.z);
                text[text.Length - 1].enabled = false;
                name.enabled = false;
            }
            else
            {
                Fout.goFade = true;
            }
        }

        if (Fout.isFaded)
        {
            SceneManager.LoadScene(1);
        }
	}
}
