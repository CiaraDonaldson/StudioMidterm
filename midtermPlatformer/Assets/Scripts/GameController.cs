using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int OneLevel = 0;
    public int TwoLevel = 0;
    public int ThreeLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        if (sceneName == "Level 1")
        {
            OneLevel = 1;
        }
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
        public void RestartButton()
        {
            SceneManager.LoadScene("the creature");
            OneLevel = 0;
            TwoLevel = 0;
            ThreeLevel = 0;
        }
    }
