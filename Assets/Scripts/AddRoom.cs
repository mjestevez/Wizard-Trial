using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomGenerator generator;
    public int numPuertas;
    public int openingDirection;
    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomGenerator>();
        generator.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
