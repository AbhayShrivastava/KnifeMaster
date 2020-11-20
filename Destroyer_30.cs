using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_30 : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.gameObject.CompareTag("TAG_0"))
        {
            Destroy(collision.gameObject);
        }
        if(collision.transform.gameObject.CompareTag("TAG_3"))
        {
            Destroy(collision.gameObject);
        }
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.CompareTag("TAG_3"))
        {
          
            Destroy(collision.gameObject);
          
        }
      

    }
 
}
