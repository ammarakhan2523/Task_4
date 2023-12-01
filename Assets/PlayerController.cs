using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 15;
    public GameObject projectilePrefab;
    private Animator playerAnim;
    private AudioSource playeAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip shootingSound;
    public AudioClip crashSound;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (transform.position.x < 0.7)
        {
            transform.position = new Vector3(0.7f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 20)
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
          
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch projectile form the player
            Instantiate(projectilePrefab,new Vector3(transform.position.x, 2 , transform.position.z) , projectilePrefab.transform.rotation);
            playeAudio.PlayOneShot(shootingSound, 1.0f);
        }
        horizontalInput = Input.GetAxis("Horizontal");
      
        if (horizontalInput < 0)
        {
            print("left");
            playerAnim.SetBool("isMoving", true);
            transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * speed);
            transform.localEulerAngles = new Vector3(0, 270, 0);
              dirtParticle.Play();
        }


        else if (horizontalInput > 0)
        {
           // print("dom");
            playerAnim.SetBool("isMoving", true);
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);


            transform.localEulerAngles = new Vector3(0, 90, 0);
            dirtParticle.Play();
        }
        else 
        {
            
            playerAnim.SetBool("isMoving", false);
            transform.localEulerAngles = new Vector3(0, -7, 0);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
          if (collision.gameObject.CompareTag("Ball"))
        {

            gameOver = true;
            Debug.Log("game over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playeAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
