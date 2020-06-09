using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Texture2D tex;
    // Start is called before the first frame update
    void Start()
    { 
            CursorMode mode = CursorMode.ForceSoftware;
            float xspot = tex.width / 2;
            float yspot = tex.height / 2;
            Vector2 hotSpot = new Vector2(xspot, yspot);
            Cursor.SetCursor(tex, hotSpot, mode);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Main");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void SalirPausa()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
