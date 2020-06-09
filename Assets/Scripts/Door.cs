using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject[] enemigos;
    private float s;
    // Start is called before the first frame update
    void Start()
    {
        s = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        if (s >= 3)
        {
            enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemigos.Length == 0)
                Destroy(this.gameObject);
            
        }
        else
            s += Time.deltaTime;
    }
}
