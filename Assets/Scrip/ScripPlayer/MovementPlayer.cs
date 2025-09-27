using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] new Transform camera;
    [SerializeField] protected int vida;
    [SerializeField] TextMeshProUGUI mensajeTexto;

    private void Start()
    {
        mensajeTexto.text = "Vida: " + vida;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");


        Vector3 dir = (camera.forward * vertical + camera.right * horizontal);
        dir.y = 0; 
        if (dir.magnitude > 1) dir.Normalize();


        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

    public void PlayerDied(int damage)
    {
        mensajeTexto.text = "Vida: " + vida;
        vida -= damage;
        mensajeTexto.text = "Vida: " + vida;
        if (vida <= 0)
        {
            SceneManager.LoadScene("Perdiste");
        }
    }

    public int Vida()
    {
        return vida;
    }
}
