using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    public AudioSource thrustAudio;      // assign your AudioSource here
    public AudioClip thrustClip;         // make sure this is public so you can drag the clip in
    public GameObject flameEffect;
    public float thrustForce = 5f;
    public KeyCode thrustKey = KeyCode.UpArrow;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thrustAudio.loop = true;
        thrustAudio.clip = thrustClip;   // assign the clip to the AudioSource at runtime
        thrustAudio.Stop();
        flameEffect.SetActive(false);
    }

    void Update()
    {
        bool isThrusting = Input.GetKey(thrustKey);

        if (isThrusting)
        {
            rb.AddForce(transform.up * thrustForce);

            if (!thrustAudio.isPlaying)
                thrustAudio.Play();

            flameEffect.SetActive(true);
        }
        else
        {
            if (thrustAudio.isPlaying)
                thrustAudio.Stop();

            flameEffect.SetActive(false);
        }
    }
}
