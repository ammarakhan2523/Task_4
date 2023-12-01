using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private Vector3 scaleChange;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("object collide");
        //if(collision.gameObject.CompareTag("Ground"))
        //{
        //  //  Destroy(gameObject);
        //}
        if (collision.gameObject.CompareTag("Laser"))
        {
            scaleChange = gameObject.transform.localScale / 2;
            gameObject.transform.localScale = scaleChange;
        }
        if (playerControllerScript.gameOver == true)
        {
            Destroy(gameObject);
        }
    }
}
