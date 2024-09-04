using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerUI : MonoBehaviour
{
    public GameObject player;  // Tham chiếu đến đối tượng player
    public GameObject tileMap; // Tham chiếu đến tileMap
    public GameObject creaEmpty; // Tham chiếu đến GameObject trống

    // Phương thức được gọi khi player vượt qua tileMap
    void Update()
    {
        ViewLoad();
    }

    public void ViewLoad()
    {
        if (player.transform.position.y < tileMap.transform.position.y)
        {
            player.SetActive(false);  // Ẩn player
            creaEmpty.SetActive(true); // Hiển thị GameObject trống
            
        }
    }

    // Phương thức để tải lại cảnh
    public void LoadSence()
    {
        // Chỉnh sửa phương thức gọi để tải lại scene
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
