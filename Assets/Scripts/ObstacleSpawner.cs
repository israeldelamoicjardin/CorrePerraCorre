using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour


{

    [SerializeField] GameObject[] obstaculos;
    Vector3 spawnPos;
    public float spawnRate= 4f;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        spawnPos = transform.position; // que empiece con el valor de mi posición objeto 3d
        StartCoroutine("SpawnObstacles");
    }

    /// <summary>
    /// con esto hacemos que se llame cada spawnrate
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();
            GameManager.Instance.UpdateScore();
            yield return new WaitForSeconds(spawnRate);
        }        
    }

    void Spawn()
    {
        int randObstaculo = Random.Range(0, obstaculos.Length); //que elija del array
        //arriba y abajo
        int randomSpot = Random.Range(0, 2);
        spawnPos = transform.position;
        if(randomSpot < 1) {
            //va arriba
            Instantiate(obstaculos[randObstaculo], spawnPos, transform.rotation);
        }
        else
        {
            //va abajo
            spawnPos.y = - transform.position.y;

            //en funcion del objeto hay que sacar uno u otro
            if(randObstaculo == 1)
            {
                // sale el objeto de tipo 2
                spawnPos.x += 2; //corrige el desplazamiento
            }
            else if (randObstaculo == 2)
            {
                // sale el objeto de tipo 3
                spawnPos.x -= 3; //corrige el desplazamiento
            }
            GameObject obs = Instantiate(obstaculos[randObstaculo], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 0180); //rotalo pues va a abajo


        }

    }
}
