using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
   

    // Start is called before the first frame update
    void Start()
    {
        // print(count);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
      

    }

}
