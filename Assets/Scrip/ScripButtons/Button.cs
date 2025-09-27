using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Button : MonoBehaviour
{
    public TextMeshProUGUI mensajeTexto;
    public void CambiarScena()
    {
        SceneManager.LoadScene("ScenaDeExplicacion");
    }

    public void CambiarScenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CambiarScenaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MostrarMensaje()
    {
        mensajeTexto.text = "El apartado de opciones no esta disponible";
    }

    public void SalirJuego()
    {

        Application.Quit();

    }

}
