using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   if (gameObject.CompareTag("Laser"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
       if(gameObject.CompareTag("Ball"))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
