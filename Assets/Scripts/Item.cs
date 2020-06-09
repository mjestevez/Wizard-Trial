using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {
    Moneda,
    Llave,
    Corazon,
    LifeUp,
    Escudo,
    EsenciaRoja,
    EsenciaAzul,
    EsenciaVerde,
};

public class Item : MonoBehaviour {
    public Type tipo;
    public int value;
    public bool tienda;
    public int costeMin;
    public int costeMax;
    public int coste;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            
            if (tienda)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Hero");
                PlayerItems pi = player.GetComponent<PlayerItems>();
                if (pi.monedas >= coste)
                {
                    bool d = true;
                    if (tipo == Type.Corazon)
                    {
                        PlayerLife pl = collision.gameObject.GetComponent<PlayerLife>();
                        d = pl.addLife(value);
                    }
                    if (d)
                    {
                        pi.monedas -= coste;
                        pi.UIMonedas.text = "x " + pi.monedas.ToString("000");
                        tienda = false;
                        Destroy(gameObject);
                    }
                    
                }
            }
            else
            {
                bool d = true;
                if (tipo == Type.Corazon)
                {
                    PlayerLife pl = collision.gameObject.GetComponent<PlayerLife>();
                    d = pl.addLife(value);
                }
                if (d) Destroy(gameObject);
            }
        }
    }
}
