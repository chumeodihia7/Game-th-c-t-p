using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update
    public string TenManChoi;
    void Start()
    {
        
    }
    public void ChuyenManChoi()
    {
        SceneManager.LoadScene(TenManChoi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            ChuyenManChoi(); 
        }
    }
}
