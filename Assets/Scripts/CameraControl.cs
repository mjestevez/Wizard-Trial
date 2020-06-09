using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private GameObject cameraa;
    public GameObject room;
	// Use this for initialization
	void Start () {
        cameraa = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            room.layer = 13;
            Transform[] hijos = room.GetComponentsInChildren<Transform>();
            for(int i= 0; i < hijos.Length; i++)
            {
                hijos[i].gameObject.layer = 13;
            }
            cameraa.transform.position = new Vector3(room.transform.position.x +8.5f, room.transform.position.y - 2.5f, cameraa.transform.position.z);
        }
    }
}
