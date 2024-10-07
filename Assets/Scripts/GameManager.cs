using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //para usarla desde todos los sitios pero que no se cr
    public bool gameStarted = false;
    public GameObject player;
    public Text vidaText;
    public Text puntosText;
    public GameObject panelUI;
    public GameObject panelJuego;
    public GameObject spawner;
    public Vector3 posicionIncialCamara;

    int lives = 2;
    int score = 0;

    private void Awake()
    {
        Instance = this;
        panelUI.SetActive(false);
        panelJuego.SetActive(true);
    }

    public void Start()
    {
        posicionIncialCamara = Camera.main.transform.position;  
    }
    public void StartGame()
    {
        gameStarted = true;
        vidaText.text = "Vida: " + lives.ToString();
        puntosText.text = "Puntos: " + score.ToString();
        panelUI.SetActive(true);
        panelJuego.SetActive(false);
        spawner.SetActive(true);

    }


 

    
      /// <summary>
      /// Procedimiento de fin de juego, descativa el juego, desactiva jugador, lanza el nivel después de 3 segundos
      /// </summary>
     
    public void GameOver()
    {
        gameStarted=false;
        player.SetActive(false);
        Invoke("ReloadLevel", 3f); //espera 5 segundos y lanza el método ReloadLevel
    }

  
     /// <summary>
     /// Cierra la aplicación
     /// </summary>
   
    public void ExitGame()
    {
        Application.Quit(); 
    }

    
     /// <summary>
     /// Reiniciar el nivel no es más que volver a cargar la misma escena
     /// </summary>
     
    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    
    /// <summary>
    /// Gestión de vidas, si llega a cero se acabo, si no es cero, decremento
    /// </summary>
     
    public void UpdateLives()
    {
        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            vidaText.text = "Vida: " + lives.ToString();
        }
    }

    
     /// <summary>
     /// Gestiónde puntos, se incrementa en el contador y se actualiza el HUD
     /// </summary>
     
    public void UpdateScore()
    {
        score++;
        puntosText.text = "Puntos: " + score.ToString();
    }

    
     /// <summary>
     /// Efecto de choque en la cámara
     /// </summary>
     
    public void Shake()
    {
        StartCoroutine("CameraShake");
    }

    
     /// <summary>
     /// Mueve la cámara 
     /// </summary>
     /// <returns></returns>
    
    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;
            Camera.main.transform.position = new Vector3 (randomPos.x, randomPos.y, posicionIncialCamara.z); //se mueve todo menos en profundidad
            yield return null;  //espera a terminar y vuelve el bucle          
        }
        Camera.main.transform.position = posicionIncialCamara;
    }
}
