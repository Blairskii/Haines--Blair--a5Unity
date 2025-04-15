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
            Instance = this;// Set the instance to this
            DontDestroyOnLoad(gameObject);// Don't destroy this object when loading new scenes

            audioSource = gameObject.AddComponent<AudioSource>();// Add an AudioSource component
            audioSource.clip = backgroundMusic;// Assign the background music clip
            audioSource.loop = true;// Loop the audio
            audioSource.playOnAwake = false;// Don't play on awake
            audioSource.volume = 0.5f;// Set volume (adjust as needed)

            audioSource.Play();// Start playing the background music
        }
        else
        {
            // Destroy duplicate AudioManager if it exists
            Destroy(gameObject);// Destroy this object
        }
    }
}
