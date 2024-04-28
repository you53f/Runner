using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PRB;
    private Animator PA;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crash;
    public AudioClip jump;
    private AudioSource AS;
    public float gravityModifier = 1;
    public float jumpForce = 10;
    public bool onGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        PRB = GetComponent<Rigidbody>();
        PA = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            PRB.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            onGround = false;
            PA.SetTrigger("Jump_trig");
            AS.PlayOneShot(jump,1);
            dirtParticle.Stop();
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtParticle.Play();
        }
        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            PA.SetBool("Death_b",true);
            PA.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            AS.PlayOneShot(crash,1);
            Debug.Log("Game Over!");
        }
    }
}
