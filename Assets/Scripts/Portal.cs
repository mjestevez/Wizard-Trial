using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject[] enemigos;
    private int Nenemigos;
    public bool activo = false;
    public float respawn = 2;
    private float s;
    public bool boss;
    // Start is called before the first frame update
    void Start()
    {
        s = respawn;
        if (boss) Nenemigos = 1;
        else Nenemigos = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            if (Nenemigos > 0)
            {
                if (s >= respawn)
                {
                    Instantiate(enemigos[Random.Range(0, enemigos.Length)], transform.position, Quaternion.identity);
                    Nenemigos--;
                    s = 0;
                }
                else
                {
                    s += Time.deltaTime;
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
