
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
   public void Exit()
    {
       Application.Quit();
    }

}
