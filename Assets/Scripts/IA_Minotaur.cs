using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IA_Minotaur : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private GameObject player;
    private Vector3 target;
    public float life;
    private float maxLife;
    private float dieTime;
    public float radio;
    private bool sFase;
    private bool looted;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero");
        maxLife = life;
        dieTime = 0;
        sFase = false;
        looted = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", 0);
        if (!sFase && life <= (maxLife / 2))
        {
            animator.SetBool("Fase2", true);
            speed *= 1.5f;
            sFase = true;
        }
        if (life <= 0)
        {
            animator.SetBool("HasLife", false);
            this.GetComponent<BoxCollider2D>().enabled = false;
            dieTime += Time.deltaTime;
            if (!looted)
            {
                int prob = 100;
                bool loot = true;
                GameObject lt_gameObject = GameObject.FindGameObjectWithTag("Loot");
                LootTables lt = lt_gameObject.GetComponent<LootTables>();
                GameObject go;
                while (loot)
                {
                    int n = Random.Range(0, 99);
                    if (n < prob)
                    {
                        go = lt.looting("Minotaur");
                        go.GetComponent<Item>().tienda = false;
                        if (go != null)
                        {
                            Instantiate(go, transform.position, Quaternion.identity);
                        }
                        prob = (int)(prob / 2);
                    }
                    else
                    {
                        loot = false;
                        looted = true;
                    }
                }
            }
            if (dieTime >= 5)
            {
                SceneManager.LoadScene("Main Menu");
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (!animator.GetBool("Intro") && !animator.GetBool("Fase2"))
            {
                target = player.transform.position;
                float distx, disty;
                distx = target.x - transform.position.x;
                disty = target.y - transform.position.y;
                if ((Mathf.Abs(distx) <= radio && Mathf.Abs(disty) <= radio) && animator.GetInteger("Attack")==0)
                {
                    animator.SetInteger("Attack", 1);
                    animator.SetFloat("Speed", 0);
                }
                else
                {
                    if (animator.GetInteger("Attack") == 0)
                    {
                       /* if (distx >= 0) animator.SetBool("Left", false);
                        else animator.SetBool("Left", true);*/
                        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                        animator.SetFloat("Speed", speed);
                    }
                }
            }  
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet_Hero" && life>0)
        {
            Proyectil scriptProyectil = collision.gameObject.GetComponent<Proyectil>();
            Debug.Log("" + scriptProyectil.damage.ToString());
            life -= scriptProyectil.damage;
        }
    }
}
