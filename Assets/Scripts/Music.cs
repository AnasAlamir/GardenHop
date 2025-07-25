using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    public void OnMusic()
    {
        musicSource.Play();
    }
    public void OffMusic()
    {
        musicSource.Stop();
    }
}
