using UnityEngine;

public class BulletSound : MonoBehaviour
{
    public AudioClip shootSound;// Assign an audio clip in the inspector

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();// Get the AudioSource component
        if (audio != null && shootSound != null)
        {
            audio.PlayOneShot(shootSound);// Play the shoot sound
        }
    }
}
