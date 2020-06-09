using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameObject go;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            GameObject lt_gameObject = GameObject.FindGameObjectWithTag("Loot");
            LootTables lt = lt_gameObject.GetComponent<LootTables>();
            go = lt.looting("Chest");
            go.GetComponent<Item>().tienda = false;
            player = GameObject.FindGameObjectWithTag("Hero");
            PlayerItems pi = player.GetComponent<PlayerItems>();
            if (pi.llaves >= 1)
            {
                pi.llaves--;
                pi.UILlaves.text = "x " + pi.llaves.ToString("00");
                Instantiate(go, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
