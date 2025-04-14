using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    void Awake()
    {
        // Check if there's already an instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = 0.5f;

            audioSource.Play();
        }
        else
        {
            // Destroy duplicate AudioManager if it exists
            Destroy(gameObject);
        }
    }
}
