using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
    public float speed;
    public Vector2 direction;
    public bool enemigo;
    private Rigidbody2D myRigidBody;
    public float damage;
    public int elemento;
    public Animator animator;
	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator= GetComponentInChildren<Animator>();
        if(!enemigo)animator.SetInteger("elemento", elemento);
    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag == "Item" || collision.tag == "Bullet_Enemy" || collision.tag == "Bullet_Hero"|| collision.tag == "Floor"))
        {
            if (!enemigo && (collision.gameObject.tag != "Hero" && collision.gameObject.tag != "SpawnPoint"))
            {
                Destroy(gameObject);

            }

            if(enemigo && (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "SpawnPoint"))
            {
                Destroy(gameObject);
            }
        }
    }

   
}
