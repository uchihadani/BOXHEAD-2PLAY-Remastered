using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MuestraPuntaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPuntajeFinal;

    private void Update()
    {
        if(ScoreManager.Instance == null)
        {
            textoPuntajeFinal.text = "Puntaje Final: 0 ";
        }
        else
        {
            textoPuntajeFinal.text = "Puntaje Final: " + ScoreManager.Instance.score.ToString();
        }
    }
}
