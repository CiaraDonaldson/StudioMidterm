using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int OneLevel = 0;
    public int TwoLevel = 0;
    public int ThreeLevel = 0;
    public int fruit = 0;

    public TextMeshProUGUI Start1;
    public TextMeshProUGUI Start2;
    public TextMeshProUGUI Start3;

    public AudioSource bg;
    
    // Start is called before the first frame update
    void Awake()
    {
        bg = GetComponent<AudioSource>();
        bg.Play(0);

    }
    void Start()
    {

        DontDestroyOnLoad(this.gameObject);
        Start1 = gameObject.GetComponent<TextMeshProUGUI>();
        Start2 = gameObject.GetComponent<TextMeshProUGUI>();
        Start3 = gameObject.GetComponent<TextMeshProUGUI>();
    
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
        if (sceneName == "Level 2")
        {
            TwoLevel = 1;
        }
        if (sceneName == "Level 3")
        {
            ThreeLevel = 1;
        }
        if (fruit == 2 && sceneName == "the creature")
        {
            StartCoroutine(End());
        }
            
    }

    public void Begining()
    {
        StartCoroutine(Begin());

    }

        public void addFruit()
        {
         fruit += 1;
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
            HealthManager.instance.Reset();
        }

    private IEnumerator Begin()
    {
        Start1.gameObject.SetActive(true);
        Start1.enabled = true;
        yield return new WaitForSeconds(3);
        Start1.gameObject.SetActive(false);
        Start1.enabled = false;
        Start2.gameObject.SetActive(true);
        Start2.enabled = true;
        yield return new WaitForSeconds(3);
        Start2.gameObject.SetActive(false);
        Start2.enabled = false;
        Start3.gameObject.SetActive(true);
        Start3.enabled = true;
        yield return new WaitForSeconds(3);
        Start3.gameObject.SetActive(false);
        Start3.enabled = false;
    }
    private IEnumerator End()
    {
        Start1.enabled = true;
        yield return new WaitForSeconds(3);
        Start1.enabled = false;
        Start2.enabled = true;
        yield return new WaitForSeconds(3);
        Start2.enabled = false;
        Start3.enabled = true;
        yield return new WaitForSeconds(3);
        Start2.enabled = false;


    }
}
