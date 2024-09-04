using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnGround : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap") || collision.gameObject.CompareTag("Enemies")) 
            moveAnhJump.check.onGround1 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap") || collision.gameObject.CompareTag("Enemies")) 
            moveAnhJump.check.onGround1 = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap") || collision.gameObject.CompareTag("Enemies"))
            moveAnhJump.check.onGround1 = true;
    }



    

   
}
   

