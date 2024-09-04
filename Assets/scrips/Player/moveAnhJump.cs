using System.Collections;
using UnityEngine;

public class moveAnhJump : MonoBehaviour
{
    [SerializeField] float force = 10f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float JumpForce;
    [SerializeField] bool rightDirection = true;
    [SerializeField] Animator ani;
    public GameObject creaEmpty; // Tham chiếu đến GameObject trống
    public bool onGround1 = true;
    public static moveAnhJump check;
    public bool JumpSecond;
    public bool isMove = true;
    public int doubleJumped = 0;

    private float moveI;
   

    void Start()
    {
        check = this;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
      
       

    }

    void Update()
    {

        Move(Time.deltaTime);
        Jump();
        Animate();
    }

    void FixedUpdate()
    {
       
    }

    void Animate()
    {
        float isJump = Mathf.Abs(rb.velocity.x);

        if (!onGround1)
        {
            ani.SetBool("OnGround", false);
        }
        else
        {
            ani.SetBool("OnGround", true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            doubleJumped++;
            if (doubleJumped == 2 && !onGround1)
            {
                ani.SetBool("jumpsecond", true);
            }
        }
        else if (onGround1)
        {
            ani.SetBool("jumpsecond", false);
        }

        if (Mathf.Abs(moveI) > 0)
        {
            if (onGround1)
            {
                ani.SetFloat("CanRun", isJump);
            }
            else
            {
                ani.SetFloat("CanRun", 0);
            }
        }
        else if (Mathf.Abs(moveI) == 0)
        {
            ani.SetFloat("CanRun", 0);
        }
    }

    void Move(float time)
    {
        moveI = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * moveI * force );

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }

        if (rightDirection && moveI < 0)
        {
            rightDirection = false;
            FlipPlayer();
        }
        else if (!rightDirection && moveI > 0)
        {
            rightDirection = true;
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        Vector3 chuyenHuong = rb.transform.localScale;
        chuyenHuong.x *= -1;
        rb.transform.localScale = chuyenHuong;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (onGround1)
            {
                onGround1 = false;
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                JumpSecond = true;
                doubleJumped = 0;
            }
            else if (JumpSecond)
            {
                JumpSecond = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            gameObject.SetActive(false);  // Ẩn player
            creaEmpty.SetActive(true); // Hiển thị GameObject trống
        }
    }
}
