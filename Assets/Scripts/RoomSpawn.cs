using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour {

    public int openingDirection;
    // 1-> need bottom door
    // 2-> need left door
    // 3-> need top door
    // 4-> need right door

    private RoomGenerator generator;
    private int rnd;
    public bool spawned = false;
    public float waitTime = 4f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, waitTime);
        generator = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomGenerator>();
        Invoke("Spawn", 0.1f);
	}

    // Update is called once per frame
    void Update(){

    }

    void Spawn () {
        if(spawned == false)
        {
            Vector2 position = new Vector2(transform.position.x - 8.5f, transform.position.y + 2.5f);
            if (openingDirection == 1)
            {
                rnd = Random.Range(0, generator.bottomRooms.Length);
                Instantiate(generator.bottomRooms[rnd], position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                rnd = Random.Range(0, generator.leftRooms.Length);
                Instantiate(generator.leftRooms[rnd], position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                rnd = Random.Range(0, generator.topRooms.Length);
                Instantiate(generator.topRooms[rnd], position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                rnd = Random.Range(0, generator.rightRooms.Length);
                Instantiate(generator.rightRooms[rnd], position, Quaternion.identity);
            }
        }
        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawn>().spawned == false && spawned == false)
            {
                Vector2 position = new Vector2(transform.position.x - 8.5f, transform.position.y + 2.5f);
                if ((openingDirection == 3 || openingDirection == 4) && (collision.GetComponent<RoomSpawn>().openingDirection == 3 || collision.GetComponent<RoomSpawn>().openingDirection == 4))
                {
                    Debug.Log("TR");
                    Instantiate(generator.TR, position, Quaternion.identity);
                }
                    
                if ((openingDirection == 1 || openingDirection == 3) && (collision.GetComponent<RoomSpawn>().openingDirection == 1 || collision.GetComponent<RoomSpawn>().openingDirection == 3))
                {
                    Debug.Log("TB");
                    Instantiate(generator.TB, position, Quaternion.identity);
                }
                    
                if ((openingDirection == 3 || openingDirection == 2) && (collision.GetComponent<RoomSpawn>().openingDirection == 3 || collision.GetComponent<RoomSpawn>().openingDirection == 2))
                {
                    Debug.Log("TL");
                    Instantiate(generator.TL, position, Quaternion.identity);
                }
                    
                if ((openingDirection == 1 || openingDirection == 2) && (collision.GetComponent<RoomSpawn>().openingDirection == 1 || collision.GetComponent<RoomSpawn>().openingDirection == 2))
                {
                    Debug.Log("BL");
                    Instantiate(generator.BL, position, Quaternion.identity);
                }
                    
                if ((openingDirection == 3 || openingDirection == 2) && (collision.GetComponent<RoomSpawn>().openingDirection == 3 || collision.GetComponent<RoomSpawn>().openingDirection == 2))
                {
                    Debug.Log("BR");
                    Instantiate(generator.BR, position, Quaternion.identity);
                }
                    
                if ((openingDirection == 2 || openingDirection == 4) && (collision.GetComponent<RoomSpawn>().openingDirection == 2 || collision.GetComponent<RoomSpawn>().openingDirection == 4))
                {
                    Debug.Log("LR");
                    Instantiate(generator.LR, position, Quaternion.identity);
                }
                Destroy(gameObject);

            }
            spawned = true;
        }
    }
}
