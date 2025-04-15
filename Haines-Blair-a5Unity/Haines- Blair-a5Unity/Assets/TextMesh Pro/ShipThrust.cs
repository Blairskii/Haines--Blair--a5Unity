using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    public AudioSource thrustAudio;
    public AudioClip thrustClip;
    public float thrustForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * thrustForce);

            if (!thrustAudio.isPlaying)
            {
                thrustAudio.clip = thrustClip;
                thrustAudio.loop = true;
                thrustAudio.Play();
            }
        }
        else
        {
            if (thrustAudio.isPlaying)
            {
                thrustAudio.Stop();
            }
        }
    }
}
