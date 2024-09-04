using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Đối tượng singleton

    [SerializeField] int currentScore = 0; // Điểm số hiện tại
    [SerializeField] TextMeshProUGUI MyText;
    void Awake()
    {
        // Đảm bảo chỉ có một instance của ScoreManager tồn tại trong toàn bộ game
        if (instance == null)
        {
            instance = this;
            /*DontDestroyOnLoad(gameObject); // Giữ game object này khi chuyển scene*/
        }
        else
        {
            Destroy(gameObject); // Destroy game object nếu đã tồn tại một instance khác
        }
    }
     void Start()
    {
        MyText.SetText(currentScore.ToString());
    }
    // Phương thức để cập nhật điểm số
    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
      /*  Debug.Log("Updated Score: " + currentScore);*/ // Debug log để kiểm tra điểm số sau khi cập nhật
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            MyText.SetText(currentScore.ToString());
        }
    }
}
