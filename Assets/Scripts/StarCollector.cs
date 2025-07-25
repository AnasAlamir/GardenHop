using UnityEngine;
using UnityEngine.UI;

public class StarCollector : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private AudioSource starSound;
    [SerializeField] private AudioSource carrotSound;
    void Start()
    {
        score = PlayerPrefs.GetInt("currentScore", 0);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("star"))
        {
            starSound.Play();
            Destroy(collision.gameObject);
            score += 100;
            scoreText.text = "Score: " + score;
            if(score > highScore)
                PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.SetInt("currentScore", score);
        }
        if (collision.gameObject.CompareTag("carrot"))
        {
            starSound.Play();
            Destroy(collision.gameObject);
            score += 350;
            scoreText.text = "Score: " + score;
            if (score > highScore)
                PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.SetInt("currentScore", score);
        }
    }
}
