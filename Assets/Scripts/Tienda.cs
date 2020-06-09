using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public GameObject[] objetos;
    public TextMesh texto;
    private GameObject objeto;
    private Item it;
    // Start is called before the first frame update
    void Start()
    {
        texto.GetComponent <MeshRenderer>().sortingLayerName = "Deafult";
        texto.GetComponent<MeshRenderer>().sortingOrder = 3;
        objeto = objetos[Random.Range(0, objetos.Length - 1)];
        objeto=Instantiate(objeto, transform.position, Quaternion.identity);
        it = objeto.GetComponent<Item>();
        it.tienda = true;
        it.coste = Random.Range(it.costeMin, it.costeMax);
        texto.text = "x" + it.coste.ToString("00");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!objeto) Destroy(gameObject);
    }
}
