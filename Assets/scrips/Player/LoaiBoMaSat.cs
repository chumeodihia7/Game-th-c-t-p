using UnityEngine;

public class LoaiBoMaSat : MonoBehaviour
{
    public float wallSlideSpeed = -3f; // Tốc độ trượt dọc theo tường (âm để nhân vật trượt xuống)
    private Rigidbody2D rb; // Rigidbody của nhân vật

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Lấy Rigidbody2D của nhân vật khi bắt đầu
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Kiểm tra mỗi điểm va chạm trong va chạm
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Kiểm tra nếu nhân vật va chạm với tường (tường nằm bên trái hoặc bên phải nhân vật)
            if (Mathf.Abs(contact.normal.x) > 0.5f)
            {
                // Đặt tốc độ y của nhân vật thành wallSlideSpeed
                rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed);
            }
        }
    }
}