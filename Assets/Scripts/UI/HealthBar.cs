using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject boat;
    Image healthBar;

	void Start ()
    {
        healthBar = GetComponent<Image>();

    }
	
	void FixedUpdate ()
    {
        healthBar.fillAmount = (boat.GetComponent<Enemy>().Health / 100f);

    }
}
