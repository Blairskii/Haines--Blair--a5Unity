using UnityEngine;

public class BulletSound : MonoBehaviour
{
    public AudioClip shootSound;

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null && shootSound != null)
        {
            audio.PlayOneShot(shootSound);
        }
    }
}
