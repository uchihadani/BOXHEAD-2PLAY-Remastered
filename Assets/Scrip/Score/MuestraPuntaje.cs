using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MuestraPuntaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPuntajeFinal;

    private void Start()
    {
        // ?? Ahora lee directamente el puntaje final
        textoPuntajeFinal.text = "Puntaje Final: " + ScoreManager.PuntajeFinal.ToString();
    }
}
