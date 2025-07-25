using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static player_move;

public class death : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator An;
    private int lives = 3;
    private const int Max_Lives = 3;
    private bool isDead = false;

    public GameObject[] heartImages;
    public Transform startPoint;
    [SerializeField] private AudioSource carrotSound;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource attackSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        An = GetComponent<Animator>();
        UpdateHeartsUI();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("carrot"))
        {
            carrotSound.Play();
            Destroy(collision.gameObject);
            if (lives < Max_Lives)
            {
                lives++;
            }
            UpdateHeartsUI();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("slug enemy") && !isDead)
        {
            if (player_move.state == MoveState.fall)
            {
                attackSound.Play();
                collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
                Destroy(collision.gameObject, (float)0.1);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, player_move.forceJump);
            }
            else
            {
                hitSound.Play();
                Die();
            }
            
            
        }
        else if (collision.gameObject.CompareTag("traps") && !isDead)
        {
            hitSound.Play();
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        An.SetTrigger("death");

        lives--;
        UpdateHeartsUI();

        if (lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            Invoke(nameof(RestartLevel), 1f);
        }
    }

    private void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = startPoint.position; 
        isDead = false;
    }

    private void RestartLevel()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        SceneManager.LoadScene("GameOver Menu"); 
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].SetActive(i < heartImages.Length - lives);
        }
    }
}
