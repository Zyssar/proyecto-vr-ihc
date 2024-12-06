using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int maxScore = 25; // Puntaje máximo para ganar
    public Text team1ScoreText; // UI Text para el puntaje del equipo 1
    public Text team2ScoreText; // UI Text para el puntaje del equipo 2

    private int team1Score = 0; // Puntaje del equipo 1
    private int team2Score = 0; // Puntaje del equipo 2

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPointToTeam1()
    {
        team1Score++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    public void AddPointToTeam2()
    {
        team2Score++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    private void UpdateScoreUI()
    {
        team1ScoreText.text = team1Score.ToString();
        team2ScoreText.text = team2Score.ToString();
    }

    private void CheckWinCondition()
    {
        if (team1Score >= maxScore)
        {
            Debug.Log("¡El Equipo 1 gana!");
            ResetGame();
        }
        else if (team2Score >= maxScore)
        {
            Debug.Log("¡El Equipo 2 gana!");
            ResetGame();
        }
    }

    private void ResetGame()
    {
        team1Score = 0;
        team2Score = 0;
        UpdateScoreUI();
        // Aquí puedes agregar lógica adicional para reiniciar la partida
    }
}
