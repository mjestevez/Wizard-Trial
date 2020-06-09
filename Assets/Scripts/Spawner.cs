using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] portales;
    public GameObject bloque;
    public GameObject[] puertas;
    public bool boss;
    public AudioClip music;
    private GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.FindGameObjectWithTag("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            if (boss)
            {
                AudioSource musica = m.GetComponent<AudioSource>();
                musica.clip = music;
                musica.Play();
            }
            for(int i=0; i < portales.Length; i++)
            {
                Portal p = portales[i].GetComponent<Portal>();
                p.activo = true;
            }
            for(int i=0; i< puertas.Length; i++)
            {
                Instantiate(bloque, puertas[i].transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);

        }
    }
    
    
}
