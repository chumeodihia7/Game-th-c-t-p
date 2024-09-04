using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    [SerializeField] int Speed;
    private Vector2 diemMucTieu;

    void Start()
    {
        diemMucTieu = posA.position;
        Speed = 5;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            diemMucTieu = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            diemMucTieu = posA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, diemMucTieu, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Bắt đầu Coroutine để đợi một khung hình trước khi thay đổi parent
            StartCoroutine(DetachAfterFrame(collision.transform));
        }
    }

    private IEnumerator DetachAfterFrame(Transform playerTransform)
    {
        // Đợi một khung hình
        yield return null;
        // Đặt parent của playerTransform về null
        playerTransform.SetParent(null);
    }
}
