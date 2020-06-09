using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {
    public float life;
    public int tipo;
    public string nombre;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
        {
            GameObject lt_gameObject = GameObject.FindGameObjectWithTag("Loot");
            LootTables lt = lt_gameObject.GetComponent<LootTables>();
            GameObject go;
            go = lt.looting(nombre);
            
            if (go != null)
            {
                if (go.GetComponent<Item>() != null) go.GetComponent<Item>().tienda = false;
                Instantiate(go, transform.position, Quaternion.identity);
            }
            int n = Random.Range(0, 99);
            if (n < 25)
            {
                go = lt.looting(nombre);
                if(go.GetComponent<Item>()!=null)go.GetComponent<Item>().tienda = false;
                if (go != null)
                {
                    Instantiate(go, transform.position, Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
            
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet_Hero")
        {
            Proyectil scriptProyectil = collision.gameObject.GetComponent<Proyectil>();
            switch (tipo){
                case 0:
                    if (scriptProyectil.elemento == 1)
                        life -= (scriptProyectil.damage + (scriptProyectil.damage * 0.1f));
                    else
                        life -= scriptProyectil.damage;
                    Debug.Log("" + life);
                    break;
                case 1:
                    if (scriptProyectil.elemento == 2)
                        life -= (scriptProyectil.damage + (scriptProyectil.damage * 0.1f));
                    else
                        life -= scriptProyectil.damage;
                    Debug.Log("" + life);
                    break;
                case 2:
                    if (scriptProyectil.elemento == 0)
                        life -= (scriptProyectil.damage + (scriptProyectil.damage * 0.1f));
                    else
                        life -= scriptProyectil.damage;
                    Debug.Log("" + life);
                    break;

            }
            
        }
    }
    
}
