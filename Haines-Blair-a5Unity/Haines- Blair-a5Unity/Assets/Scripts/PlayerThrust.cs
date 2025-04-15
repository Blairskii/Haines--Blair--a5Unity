using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class PlayerThrust : MonoBehaviour 
{
    public float thrustForce = 5f; // Adjust this value to change thrust strength
    public AudioClip thrustClip; // Assign an audio clip in the inspector
    public GameObject flameEffect; // Assign a flame effect prefab in the inspector

    private Rigidbody2D rb;// Rigidbody2D component
    private AudioSource audioSource;// AudioSource component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// Get the Rigidbody2D component
        audioSource = GetComponent<AudioSource>();// Get the AudioSource component

        // Set up audio source properties
        audioSource.clip = thrustClip;// Assign the audio clip
        audioSource.loop = true;// Loop the audio
        audioSource.playOnAwake = false;// Don't play on awake

        if (flameEffect != null)// Instantiate the flame effect
            flameEffect.SetActive(false); // hide flame on start
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))// Check if Space key is pressed
        {
            rb.AddForce(transform.up * thrustForce);// Apply thrust force in the direction the player is facing

            if (!audioSource.isPlaying)// Check if audio is not already playing
                audioSource.Play();// Play the thrust sound

            if (flameEffect != null && !flameEffect.activeSelf)// Check if flame effect is not already active
                flameEffect.SetActive(true);// Activate the flame effect
        }
        else
        {
            if (audioSource.isPlaying)// Stop the audio if it's playing
                audioSource.Stop();// Stop the thrust sound

            if (flameEffect != null && flameEffect.activeSelf)// Check if flame effect is active
                flameEffect.SetActive(false);// Deactivate the flame effect
        }
    }
}
