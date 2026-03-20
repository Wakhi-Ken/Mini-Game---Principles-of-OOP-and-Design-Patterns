using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text healthText;
    public Text medkitText;
    public Text timerText;

    public GameObject gameOverPanel;
    public Text finalScoreText;

    private PlayerController player;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (player != null)
        {
            // Update UI
            healthText.text = "Health: " + Mathf.Round(player.GetHealth());
            medkitText.text = "Medkits: " + player.medkitsCollected;
            timerText.text = "Time: " + Mathf.Floor(Time.timeSinceLevelLoad) + "s";
        }
    }

    public void GameOver(int medkits, float timeSurvived)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Survived: " + Mathf.Floor(timeSurvived) + "s\nMedkits: " + medkits;
        Time.timeScale = 0f; // Freeze game
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}