using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour {
    public int monedas;
    public Text UIMonedas;
    public int llaves;
    public Text UILlaves;
	// Use this for initialization
	void Start () {
        monedas = 0;
        llaves = 1;
        UIMonedas.text = "x " + monedas.ToString("000");
        UILlaves.text = "x " + llaves.ToString("00");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            if (!item.tienda)
            {
                PlayerController player = gameObject.GetComponent<PlayerController>();
                PlayerLife pl = gameObject.GetComponent<PlayerLife>();
                if (item.tipo == Type.Moneda)
                {
                    monedas += item.value;
                    if (monedas > 999) monedas = 999;
                    UIMonedas.text = "x " + monedas.ToString("000");
                    return;
                }
                if (item.tipo == Type.Llave)
                {
                    llaves += item.value;
                    if (llaves > 99) llaves = 99;
                    UILlaves.text = "x " + llaves.ToString("00");
                }
                if (item.tipo == Type.Corazon)
                {
                    pl.addLife(item.value);
                }
                if (item.tipo == Type.EsenciaRoja)
                {
                    float n = player.damage * ((item.value / 100.00f) + 1.00f);
                    player.damage = n;
                }
                if (item.tipo == Type.EsenciaAzul)
                {
                    float n = player.attack_speed * (item.value / 100.00f);
                    player.attack_speed -= n;
                }
                if (item.tipo == Type.EsenciaVerde)
                {
                    float n = player.startSpeed * ((item.value / 100.00f) + 1.00f);
                    player.startSpeed = n;
                }
                if (item.tipo == Type.LifeUp)
                {
                    pl.max_life += 2;
                    pl.addLife(pl.max_life - pl.life);
                }
            }
        }
    }
}
