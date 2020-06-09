using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Slime : MonoBehaviour {
    public float speed;
    private GameObject player;
    private Vector3 target;
    private bool left;
    private int attack;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Hero");
	}
	
	// Update is called once per frame
	void Update () {
        target = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
	}
}
