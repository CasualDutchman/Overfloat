using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject[] clouds;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<Cloud>())
            Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(Camera.main.transform.position.x + 27.75f, 12.7f, 31.5f), Quaternion.identity);
    }
}
