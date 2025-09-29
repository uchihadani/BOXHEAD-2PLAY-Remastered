using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    //Enemigos y SpawnPoints
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    //tiempo entre enemigos
    [SerializeField] private float timeBetweenEnemy = 5f;

    //UI
    [SerializeField] private TextMeshProUGUI mensajeOleada;

    //variables
    private float timer = 0f;
    private int cantidadEnemigos = 0;
    private int oleadaA = 0;
    private bool enOleada = false;

    private int[] enemigosPorOleada = new int[10]
    {
        5, 10, 15, 20, 25, 30, 35, 40, 45, 50
    };

    void Start()
    {
        ActualizarMensaje("Presiona X para iniciar la oleada");
    }

    private void Update()
    {
        if (!enOleada)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                IniciarOleada();
            }
            return;
        }

        if(cantidadEnemigos < enemigosPorOleada[oleadaA])
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenEnemy)
            {
                SpawEnemy();
                timer = 0f;
            }
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                TerminarOleada();
            }
        }

    }

    private void SpawEnemy()
    {
        int random = Random.Range(0, enemyPrefabs.Count);
        int randomSpawn = Random.Range(0, spawnPoints.Count);

        Instantiate(enemyPrefabs[random], spawnPoints[randomSpawn].position, Quaternion.identity);
        cantidadEnemigos++;

    }

    private void IniciarOleada()
    {
        enOleada = true;
        cantidadEnemigos = 0;
        ActualizarMensaje("Oleada " + (oleadaA + 1) + " en progreso");
    }

    private void TerminarOleada()
    {
        enOleada = false;
        oleadaA++;
        if(oleadaA < enemigosPorOleada.Length -1)
        {
            ActualizarMensaje("Oleada " + oleadaA + " terminada. Presiona X para iniciar la siguiente oleada");
        }
        else if (oleadaA == enemigosPorOleada.Length -1)
        {
            ActualizarMensaje("Ultima oleada completada! Presiona X para iniciar la oleada final");
        }
        else
        {
            SceneManager.LoadScene("Ganaste");
        }
    }

    private void ActualizarMensaje(string texto)
    {
        if(mensajeOleada != null)
        {
            mensajeOleada.text = texto;
        }
    }
}




















