using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {
    public int life;
    public int max_life;
    public int damageTaken;
    public bool invunerable;
    public float tiempo_invunerable;
    private float cooldown = 0;
    public Image full;
    public Image half;
    public Image zero;
    public GameObject position;
    public Canvas myCanvas;
    public Animator animator;
    private float dead = 5;
    public Canvas canvas;
    public AudioSource musica;
    // Use this for initialization
    void Start() {
        Life();
    }

    // Update is called once per frame
    void Update() {

        Dead();
        Cooldown();
    }
    public bool addLife(int value)
    {
        int l = life;
        if ((l + value) <= max_life)
        {
            life += value;
            if (life > max_life) life = max_life;
            Life();
            return true;

        }
        return false;
    }
    private void Life()
    {
        GameObject[] corazones = GameObject.FindGameObjectsWithTag("Interfaz_Heart");
        for (int i = 0; i < corazones.Length; i++)
        {
            Destroy(corazones[i]);
        }
        Vector3 pos = position.transform.position;
        int imax, imin;
        imax = max_life / 2;
        imin = life;
        for (int i = 0; i < imax; i++)
        {
            if (i == 10)
            {
                pos.y -= 40;
                pos.x -= 400;
            }
            if (imin > 1)
            {
                Instantiate(full, pos, Quaternion.identity, myCanvas.transform);
                pos.x += 40;
                imin -= 2;
            }
            else
            {
                if (imin == 1)
                {
                    Instantiate(half, pos, Quaternion.identity, myCanvas.transform);
                    pos.x += 40;
                    imin -= 1;
                }
                else
                {
                    Instantiate(zero, pos, Quaternion.identity, myCanvas.transform);
                    pos.x += 40;
                }
            }
        }


    }
    private void Dead()
    {
        if (life <= 0)
        {
            animator.SetBool("HasLive", false);
            canvas.enabled = false;
            dead -= Time.deltaTime;
            musica.volume-=0.005f;
            PlayerController pc= this.gameObject.GetComponent<PlayerController>();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies != null)
            {
                for(int i=0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }
            }
            if (pc != null) Destroy(pc);
            if (dead <= 0)
            {
                SceneManager.LoadScene("Main Menu");

            }
        }           
    }

    private void Cooldown()
    {
        if (invunerable)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= tiempo_invunerable)
            {
                cooldown = 0;
                invunerable = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!invunerable && collision.gameObject.tag == "Enemy")
        {
            life -= damageTaken;
            invunerable = true;
            Life();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!invunerable && collision.gameObject.tag == "Bullet_Enemy")
        {
            life -= damageTaken;
            invunerable = true;
            Life();
        }
    }

    

}
