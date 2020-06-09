using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesoro : MonoBehaviour
{
    public GameObject[] tesoros;
    public GameObject centro;
    public GameObject tesoro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tesoro=Instantiate(tesoros[Random.Range(0, tesoros.Length)], centro.transform.position, Quaternion.identity);
        tesoro.GetComponent<Item>().tienda = false;
        Destroy(this);
    }
}
