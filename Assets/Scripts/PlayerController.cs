using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float startSpeed;
    public float speed;
    public float attack_speed;
    public float bullet_speed;
    public bool canFire;
    public float damage;
    private Vector2 direction;
    private int direc;
    public Animator animator;
    private bool isAttacking =false;
    private int attack_direc;
    private Vector2 attack_direction;
    private Vector2 attack_position;
    private Vector3 mousepos;
    public GameObject fireball;
    private float cooldown=0;
    public int elemento;
    public GameObject fire;
    public GameObject water;
    public GameObject plant;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private bool canDash;
    public AudioClip aFire;
    public AudioClip aWater;
    public AudioClip aPlant;
    private AudioSource sonido;
    public Canvas interfaz;
    public Canvas pausa;
    private bool pausado;
    // Use this for initialization
    void Start () {
        dashTime = 0;
        speed = startSpeed;
        canDash = true;
        sonido = gameObject.GetComponent<AudioSource>();
        pausado = false;
    }
	
	// Update is called once per frame
	void Update () {
        isAttacking = false;
        Cooldown();
        GetInput();
        animator.SetFloat("Speed", direc*speed);
        animator.SetInteger("Direction", direc);
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetInteger("Attack_Direction", attack_direc);
        Move();

    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        speed = startSpeed;
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
    private void GetInput()
    {
        
            direction = Vector2.zero;
            direc = 0;
            attack_direction = Vector2.zero;
            attack_direc = 0;
            attack_position = Vector2.zero;
            mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 16));
            dashTime -= Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (pausado)
                {
                    pausa.enabled = false;
                    interfaz.enabled = true;
                    pausado = false;
                    Time.timeScale = 1;
                }
                else
                {
                    interfaz.enabled = false;
                    pausa.enabled = true;
                    pausado = true;
                    Time.timeScale = 0;
                }

            }
        if (!pausado)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector2.up;
                direc = 1;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector2.right;
                direc = 2;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                direction += Vector2.down;
                direc = 3;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction += Vector2.left;
                direc = 4;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                elemento = (elemento + 1) % 3;
                if (elemento == 0)
                {
                    plant.SetActive(false);
                    fire.SetActive(true);
                    sonido.clip = aFire;
                    sonido.volume = 0.45f;
                }
                if (elemento == 1)
                {
                    fire.SetActive(false);
                    water.SetActive(true);
                    sonido.clip = aWater;
                    sonido.volume = 0.25f;
                }
                if (elemento == 2)
                {
                    water.SetActive(false);
                    plant.SetActive(true);
                    sonido.clip = aPlant;
                    sonido.volume = 0.15f;
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (canFire)
                {
                    attack_position = new Vector2(mousepos.x, mousepos.y);
                    attack_direction = new Vector2((attack_position.x - transform.position.x), (attack_position.y - transform.position.y));
                    isAttacking = true;
                    if (Mathf.Abs(attack_direction.x) >= Mathf.Abs(attack_direction.y))
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
                    }
                    Proyectil scriptProyectil = fireball.GetComponent<Proyectil>();
                    scriptProyectil.speed = bullet_speed;
                    scriptProyectil.direction = attack_direction;
                    scriptProyectil.enemigo = false;
                    scriptProyectil.damage = damage;
                    scriptProyectil.elemento = elemento;
                    Instantiate(fireball, transform.position, Quaternion.identity);
                    sonido.Play();
                    canFire = false;
                }
            }
            if (Input.GetMouseButton(1))
            {
                if (dashTime <= 0 && canDash)
                {

                    if (direc != 0)
                    {
                        dashTime = startDashTime;
                        speed += dashSpeed;
                    }
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canDash = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canDash = true;
    }
}
