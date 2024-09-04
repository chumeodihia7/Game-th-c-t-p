using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStart : MonoBehaviour
{
    [SerializeField] Animator animatorr;
    // Start is called before the first frame update
    void Start()
    {
        animatorr=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animatorr.SetBool("isPlayerHit", true);
            moveAnhJump.check.onGround1 = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animatorr.SetBool("isPlayerHit", false);
            moveAnhJump.check.onGround1 =false ;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            moveAnhJump.check.onGround1 = true;
        }
    }
}
