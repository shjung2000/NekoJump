using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverLogic : MonoBehaviour
{
    public Text scoreDescription;
    public Text scoreText;
    private bool isHighScore;
    private int score;

    public GameObject nekoNoHighScore;
    public GameObject nekoHighScore;
    // Start is called before the first frame update
    void Start()
    {
        RecordData data = ScoreSave.loadHighScore();
        isHighScore = data.isHighScore;
        score = data.score;

        if(isHighScore)
        {
            //It is high score
            scoreDescription.text = "New Best!";
            nekoHighScore.SetActive(true);
            
        }
        else
        {
            scoreDescription.text = "Best";
            nekoNoHighScore.SetActive(true);
            
        }

        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1.0f;
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1.0f;
    }
}
