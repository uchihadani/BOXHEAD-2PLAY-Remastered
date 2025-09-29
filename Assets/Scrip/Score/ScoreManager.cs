using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI textoPuntaje;

    public static ScoreManager Instance => instance;

    public int score = 0;

    // ?? Nuevo: variable estática para guardar el puntaje final
    public static int PuntajeFinal = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void AddPoint(int newScore)
    {
        score += newScore;
        PuntajeFinal = score; // ?? Guardamos siempre el último puntaje

        if (textoPuntaje != null)
            textoPuntaje.text = "Score: " + score.ToString();
    }
}
