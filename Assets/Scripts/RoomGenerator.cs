using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject TR;
    public GameObject TB;
    public GameObject TL;
    public GameObject BR;
    public GameObject BL;
    public GameObject LR;
   public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    private bool spawnedTreasure;
    public GameObject bossT;
    public GameObject bossR;
    public GameObject bossB;
    public GameObject bossL;
    public GameObject tesoroT;
    public GameObject tesoroR;
    public GameObject tesoroB;
    public GameObject tesoroL;

    // Use this for initialization
    void Start () {
        spawnedBoss = false;
        spawnedTreasure = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(waitTime <= 0 && spawnedBoss == false)
        {
            for(int i= rooms.Count-1; i>=0; i--)
            {
                if (spawnedBoss == false)
                {
                    AddRoom r = rooms[i].GetComponent<AddRoom>();
                    if (r.numPuertas == 1)
                    {
                        if (r.openingDirection == 1)
                        {
                            Instantiate(bossT, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }else
                            if (r.openingDirection == 2)
                        {
                            Instantiate(bossR, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }
                        else
                            if (r.openingDirection == 3)
                        {
                            Instantiate(bossB, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }
                        else
                            if (r.openingDirection == 4)
                        {
                            Instantiate(bossL, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }
                        
                            spawnedBoss = true;
                    }
                }
            }
        }

        if (waitTime <= 0 && spawnedTreasure == false)
        {
            for (int i = 0; i <rooms.Count; i++)
            {
                if (spawnedTreasure == false)
                {
                    AddRoom r = rooms[i].GetComponent<AddRoom>();
                    if (r.numPuertas == 1)
                    {
                        if (r.openingDirection == 1)
                        {
                            Instantiate(tesoroT, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }
                        else
                            if (r.openingDirection == 2)
                        {
                            Instantiate(tesoroR, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }
                        else
                            if (r.openingDirection == 3)
                        {
                            Instantiate(tesoroB, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }
                        else
                            if (r.openingDirection == 4)
                        {
                            Instantiate(tesoroL, rooms[i].transform.position, Quaternion.identity);
                            Destroy(rooms[i]);
                        }

                        spawnedTreasure = true;
                    }
                }
            }
        }
        waitTime -= Time.deltaTime;
	}
}
