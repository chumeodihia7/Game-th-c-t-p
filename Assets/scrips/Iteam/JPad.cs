using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JPad : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D JumPad;
    [SerializeField] float JumpForce;
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        JumPad = Player.GetComponent<Rigidbody2D>();
        JumpForce = 8.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveAnhJump.check.onGround1 = true;
            animator.SetBool("On", true);
            JumPad.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            moveAnhJump.check.onGround1 = false;
            animator.SetBool("On", false);
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
