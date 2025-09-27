using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int vida;
    [SerializeField] protected int daño;
    [SerializeField] protected float speed;
    [SerializeField] float distanciaA;
    [SerializeField] TextMeshProUGUI mensaje;

    protected Transform player;

    private void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if(jugador != null)
        {
            player = jugador.transform;
        }

        
    }
    private void Update()
    {
        if (player != null)
        {
            float distancia = Vector3.Distance(transform.position, player.position);

            if (distancia < distanciaA)
            {
                SeguirJugador();
            }
            if (CompareTag("Player"))
            {
                EnemyDie();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MovementPlayer jugador = collision.gameObject.GetComponent<MovementPlayer>();
            if (jugador != null)
            {
                Atacar(jugador);
            }
        }
    }

    virtual public void SeguirJugador()
    {
        Vector3 direccion = (player.position - transform.position).normalized;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, 10f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    virtual public void EnemyDie()
    {
        vida--;
        Debug.Log("vida enemigo: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    virtual public void Atacar(MovementPlayer player)
    {
        player.PlayerDied(daño);
        if (vida <= 0)
        {
            SceneManager.LoadScene("Perdiste");
        }
    }

}
