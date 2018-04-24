using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLooper : MonoBehaviour
{
    public GameObject[] Boats;
    public Transform rotator;

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Enemy>())
        {
            GameObject go = Instantiate(Boats[Random.Range(0, Boats.Length)], transform.position, Quaternion.identity) as GameObject;
            go.transform.Find("DO").GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0, 6.24f, 2f);

            go.GetComponent<Waves>().rotator = rotator;
        }
        Destroy(col.gameObject);
        
    }
}
