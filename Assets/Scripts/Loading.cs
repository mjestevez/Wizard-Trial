using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public Image progressImage;
    public AudioSource musica;
    private float tiempo;
    private float carga;
    private float t;
    private GameObject player;
    private PlayerController pc;
    public Canvas pausa;
    
    private void Start()
    {
        tiempo = 10;
        carga = 0.0f;
        t = 0.0f;
        pausa.enabled = false;
        player = GameObject.FindGameObjectWithTag("Hero");
        pc = player.GetComponent<PlayerController>();
        pc.enabled = false;
      
    }

    private void Update()
    {
        t += Time.deltaTime;
        carga = (t * tiempo) / 100;
        progressImage.fillAmount = carga;

        if (carga >= 1)
        {
            pc.enabled = true;
            musica.Play();
            Destroy(this.gameObject);
        }
    }

}
