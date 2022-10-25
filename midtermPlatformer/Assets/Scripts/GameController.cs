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

    private int done = 0;
    public TextMeshProUGUI Start1;
    public TextMeshProUGUI End11;
    public TextMeshProUGUI End21;
    public TextMeshProUGUI End31;
  
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
        else if (sceneName == "Level 2")
        {
            TwoLevel = 1;
        }
        else if (sceneName == "Level 3")
        {
            ThreeLevel = 1;
        }
        
      

        else if (fruit == 2 && sceneName == "the creature")
        {
            if (OneLevel == 1 && TwoLevel == 1)
            {
                StartCoroutine(End());
            }
            if (OneLevel == 1 && ThreeLevel == 1)
            {
                StartCoroutine(End2());
            }
            if (ThreeLevel == 1 && TwoLevel == 1)
            {
                StartCoroutine(End3());
            }
        }  
    }

    public IEnumerator Begin()
    {
        Start1.gameObject.SetActive(true);
        Start1.enabled = true;
        yield return new WaitForSeconds(3);
        Start1.text = "I'm afraid I am sick, and in need of two special fruits...";
        yield return new WaitForSeconds(3);
        Start1.text = "Please bring them to me and I shall reward you with your form.";
        yield return new WaitForSeconds(3);
        Start1.gameObject.SetActive(false);
        Start1.enabled = false;
        done += 1;
    }
    private IEnumerator End()
    {
        End11.gameObject.SetActive(true);
        End11.enabled = true;
        yield return new WaitForSeconds(3);
        End11.text = "";
        yield return new WaitForSeconds(3);
        End11.text = "";
        yield return new WaitForSeconds(3);
        End11.gameObject.SetActive(false);
        End11.enabled = false;


    }
    private IEnumerator End2()
    {
        End21.gameObject.SetActive(true);
        End21.enabled = true;
        yield return new WaitForSeconds(3);
        End21.text = "";
        yield return new WaitForSeconds(3);
        End21.text = "";
        yield return new WaitForSeconds(3);
        End21.gameObject.SetActive(false);
        End21.enabled = false;

    }
    private IEnumerator End3()
    {
        End31.gameObject.SetActive(true);
        End31.enabled = true;
        yield return new WaitForSeconds(3);
        End31.text = "";
        yield return new WaitForSeconds(3);
        End31.text = "";
        yield return new WaitForSeconds(3);
        End31.gameObject.SetActive(false);
        End31.enabled = false;

    }

    public void Begining()
    {
        
       // StartCoroutine(Begin());

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


}
