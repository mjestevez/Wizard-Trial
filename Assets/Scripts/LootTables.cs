using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LootTables : MonoBehaviour
{
    private List<List<string> > table;
    private List<string> indice;
    public List<GameObject> loot;
    public List<string> loot_indice;
    string contenido;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Datos/Enemies");
        contenido = txtAsset.text;
        indice = new List<string>();
        table = new List<List<string>>();
        StringReader file = new StringReader(contenido);
        string line;
        while((line = file.ReadLine())!= null){
            indice.Add(line);
        }
        file.Close();
        Debug.Log("" + indice.Count);
        for (int i = 0; i <indice.Count; i++)
        {
            table.Add(new List<string>());
            txtAsset = Resources.Load<TextAsset>("Datos/"+indice[i]);
            contenido = txtAsset.text;
            file = new StringReader(contenido);
            while ((line = file.ReadLine()) != null)
            {
                string[] datos = line.Split(';');
                int n = int.Parse(datos[0]);
                for(int j =0; j < n; j++)
                {
                    table[i].Add(datos[1]);
                }
            }
            file.Close();
        }
    }
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject looting(string nombre)
    {
        /* Gameobjects id
         0: Key
         1: Gold
         2: Platinum
         3: Diamond
         4: Blue
         5: Red
         6: Green
         7: Up
         8: Heart
         9: Chest
         */
        string objeto="";
        Debug.Log("" + indice.Count);
        for(int i=0; i < indice.Count; i++)
        {
            if (nombre == indice[i])
            {
                int o = Random.Range(0, 99);
                objeto = table[i][o];
            }
        }
        if (objeto == "Nothing") return null;

        int id = -1;
        for (int i = 0; i < loot_indice.Count; i++)
        {
            if (objeto == loot_indice[i])
            {
                id = i;
                break;
            }
        }
        if (id != -1)
        {
            Debug.Log("" + objeto + ";" + id);
            return loot[id];
        }else return null;
    }

}
