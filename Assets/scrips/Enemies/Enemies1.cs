using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PosA;
    public Transform PosB;
    public Vector2 DiemMucTieu;
    public int Speed;
    Animator Animator;  
    void Start()
    {
        DiemMucTieu = PosA.position;
        Speed = 5;
        Animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PosA.position) < 0.1)
        {
            DiemMucTieu = PosB.position;
            Vector3 ChuyenHuong = transform.localScale;
            ChuyenHuong.x *= -1;
            transform.localScale = ChuyenHuong;
        }
        if (Vector2.Distance(transform.position, PosB.position) < 0.1)
        {
            DiemMucTieu = PosA.position;
            Vector3 ChuyenHuong = transform.localScale;
            ChuyenHuong.x *= -1;
            transform.localScale = ChuyenHuong;
        }
        transform.position = Vector2.MoveTowards(transform.position, DiemMucTieu, Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        // Kiểm tra xem va chạm với Player hay không
        if (other.CompareTag("Player"))
        {
            Animator.SetTrigger("kich");
            // Kiểm tra xem Collider nào đã va chạm
            CapsuleCollider2D capsuleCollider = other.GetComponent<CapsuleCollider2D>();
            if (capsuleCollider != null)
            {
                // Nếu va chạm với CapsuleCollider2D thì kẻ địch biến mất
                Destroy(gameObject,0.2f);
            }
        }
    }
}




