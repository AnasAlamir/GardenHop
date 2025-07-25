
using UnityEngine;
using UnityEngine.SceneManagement ;
public class win : MonoBehaviour
{
    [SerializeField] private AudioSource winSound ;
    bool isComlete = false ;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "player" && !isComlete)
        {
            winSound.Play();
            isComlete = true ;
            Invoke ("completeLevel",1f);
            
        }
    }
    void completeLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
