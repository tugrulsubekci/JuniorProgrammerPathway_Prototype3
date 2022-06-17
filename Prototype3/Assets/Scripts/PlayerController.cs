using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Sound Effects
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public int jumpPower = 10;
    public float gravityModifier;
    public bool gameOver = false;

    // Run
    public bool doubleSpeed = false;

    // double jump
    private int numberOfJumps = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numberOfJumps < 2 && !gameOver)
        {
            Jump(jumpPower);
            dirtParticle.Stop();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void Jump(int jumpPower)
    {

        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        numberOfJumps++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            numberOfJumps = 0;
            if (!gameOver)
            {
                dirtParticle.Play();
            }

        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    private void Run()
    {

    }
}