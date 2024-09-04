using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Animator ami;
    [SerializeField] Rigidbody2D gavityScale;
    [SerializeField] Collider2D IsTrigg;
    // Start is called before the first frame update
    void Start()
    {
        ami = GetComponent<Animator>();
        gavityScale = GetComponent<Rigidbody2D>();
        IsTrigg = GetComponent<Collider2D>();
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ami.SetTrigger("kick");

            moveAnhJump.check.onGround1 = true;
            StartCoroutine(ChangeGravityAfterDelay(0.1555f)); // Gọi coroutine để thay đổi gravityScale sau 1 giây

            IsTrigg.isTrigger = true;
            Destroy(this.gameObject, 2f);

        }
    }
    private IEnumerator ChangeGravityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Đợi trong khoảng thời gian delay
        gavityScale.gravityScale = 10f; // Thay đổi giá trị gravityScale
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            moveAnhJump.check.onGround1 = false;
            IsTrigg.isTrigger = false;
        }
        /* else if (collision.gameObject.CompareTag("tilemap"))
         {
             IsTrigg.isTrigger = false;
         }*/

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            moveAnhJump.check.onGround1 = true;
        }
    }
}