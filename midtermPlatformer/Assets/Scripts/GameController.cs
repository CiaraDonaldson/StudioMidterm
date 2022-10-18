using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }

    public void StartButton()
    {
        SceneManager.LoadScene("the creature");
    }
}
