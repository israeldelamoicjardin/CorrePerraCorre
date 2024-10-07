using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float playerYpos;
    Rigidbody rb;
    public GameObject particulas;


    /// <summary>
    /// Tiempo en segundos entre toques
    /// </summary>
    private float tiempoEntreToques = 0.2f;
    private float tiempoUltimoToque = 0f;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        playerYpos = transform.position.y;  
        rb = GetComponent<Rigidbody>();      
       
    }

    /// Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStarted) // solo si ha empezado el juego
        {
            if (!particulas.activeInHierarchy)
            {
                particulas.SetActive(true);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CambiaPosicion();
            }
            // Verificar si ha pasado el tiempo suficiente desde el último toque
            if ((Time.time - tiempoUltimoToque >= tiempoEntreToques) && Input.touchCount > 0)
            {
                // Actualizar el tiempo del último toque
                tiempoUltimoToque = Time.time;

                // Ejecutar la acción
                CambiaPosicion();
            }
        }

      
    }

    /// <summary>
    /// Cambia de posición en el eje y 
    /// </summary>
    private void CambiaPosicion()
    {
        playerYpos = -playerYpos;
        transform.position = new Vector3(transform.position.x, playerYpos, transform.position.z);
    }


    /// <summary>
    /// Lo que ocurre cuando colisionan dos objetos
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //te has chocado, muere
            // SceneManager.LoadScene("Game");
            GameManager.Instance.UpdateLives(); //todos estos eventos estan centralizados en la instancia estática de GameManager
            GameManager.Instance.Shake();
        }
    }
}
