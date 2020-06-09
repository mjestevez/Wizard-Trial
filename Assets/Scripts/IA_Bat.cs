using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Bat : MonoBehaviour {
    public float speed;
    private GameObject player;
    private Vector3 target;
    private int direction;
    public Animator animator;
    private bool canFire;
    private float cooldown;
    public float radio;
    public float attack_speed;
    public GameObject bullet;
    //private int attack_direc;
    private Vector2 attack_direction;
    private Vector2 attack_position;
    public float bullet_speed;
    public float damage;
    private AudioSource sonido;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Hero");
        direction = 3;
        canFire = false;
        cooldown = attack_speed;
        sonido = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        target = player.transform.position;
        float distx, disty;
        distx = target.x - transform.position.x;
        disty = target.y - transform.position.y;
        if (Mathf.Abs(distx) > Mathf.Abs(disty))
        {
            if (distx > 0) direction = 2;
            else
                direction = 4;
        }else
        {
            if (disty > 0) direction = 1;
            else
                direction = 3;
        }
        animator.SetInteger("Direction", direction);
        if (Mathf.Abs(distx) <= radio && Mathf.Abs(disty) <= radio) disparo();
        else transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void Cooldown()
    {
        if (!canFire)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= attack_speed)
            {
                cooldown = 0;
                canFire = true;
            }
        }
    }
    private void disparo()
    {
        if (canFire)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Hero");
            attack_position = new Vector2(player.transform.position.x, player.transform.position.y);
            attack_direction = new Vector2((attack_position.x - transform.position.x), (attack_position.y - transform.position.y));
            /*if (Mathf.Abs(attack_direction.x) >= Mathf.Abs(attack_direction.y))
            {
                if (attack_direction.x >= 0) attack_direc = 2;
                else
                    attack_direc = 4;
            }
            else
            {
                if (attack_direction.y >= 0) attack_direc = 1;
                else
                    attack_direc = 3;
            }*/
            Proyectil scriptProyectil = bullet.GetComponent<Proyectil>();
            scriptProyectil.speed = bullet_speed;
            scriptProyectil.direction = attack_direction;
            scriptProyectil.enemigo = true;
            Instantiate(bullet, transform.position, Quaternion.identity);
            sonido.Play();
            canFire = false;
        }
        else
        {
            Cooldown();
        }
    }
}
