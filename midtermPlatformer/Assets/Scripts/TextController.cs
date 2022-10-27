using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextController : MonoBehaviour
{
    public int fruit = 0;

    public TextMeshProUGUI Start1;
    public TextMeshProUGUI Continue1;
    public TextMeshProUGUI End11;
    public TextMeshProUGUI End21;
    public TextMeshProUGUI End31;

    public GameObject fox;
    public GameObject wolf;
    public GameObject bear;
    public GameObject player;

    public GameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameController.FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {

        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        if (fruit == 0 && sceneName == "the creature")
        {
            StartCoroutine(Begin());
        }

        else if (fruit == 1 && sceneName == "the creature")
        {
            StartCoroutine(Continue());
        }

        else if (fruit == 2 && sceneName == "the creature")
        {
            if (GameController.OneLevel == 1 && GameController.TwoLevel == 1)
            {
                StartCoroutine(End());
            }
            else if (GameController.OneLevel == 1 && GameController.ThreeLevel == 1)
            {
                StartCoroutine(End2());
            }
            else if (GameController.ThreeLevel == 1 && GameController.TwoLevel == 1)
            {
                StartCoroutine(End3());
            }
        }

    }
    public IEnumerator Begin()
    {
        yield return new WaitForSeconds(1);
        Start1.gameObject.SetActive(true);
        Start1.enabled = true;
        yield return new WaitForSeconds(3);
        Start1.text = "I'm afraid I am sick, and in need of two special fruits...";
        yield return new WaitForSeconds(3);
        Start1.text = "Please bring them to me and I shall reward you with your form.";
        yield return new WaitForSeconds(3);
        Start1.gameObject.SetActive(false);
        Start1.enabled = false;

    }
    public IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        Continue1.gameObject.SetActive(true);
        Continue1.enabled = true;
        Continue1.text = "You are doing well child!";
        yield return new WaitForSeconds(3);
        Continue1.text = "One more fruit to cure me..";
        yield return new WaitForSeconds(3);
        Continue1.gameObject.SetActive(false);
        Continue1.enabled = false;

    }
    private IEnumerator End()
    {
        yield return new WaitForSeconds(1);
        End11.gameObject.SetActive(true);
        End11.enabled = true;
        End11.text = "Ah the fruits of Agility, Dashing and Wall Jumping..";
        yield return new WaitForSeconds(3);
        End11.text = "There's only one creature who you could be!";
        yield return new WaitForSeconds(3);
        End11.gameObject.SetActive(false);
        End11.enabled = false;

        Instantiate(fox, player.transform);
        Destroy(player);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("End");


    }
    private IEnumerator End2()
    {
        yield return new WaitForSeconds(1);
        End21.gameObject.SetActive(true);
        End21.enabled = true;
        End21.text = "Ah the fruits of Power, Dashing and Disintegration";
        yield return new WaitForSeconds(3);
        End21.text = "There's only one creature who you could be!";
        yield return new WaitForSeconds(3);
        End21.gameObject.SetActive(false);
        End21.enabled = false;

        Instantiate(bear, player.transform);
        Destroy(player);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("End 1");

    }
    private IEnumerator End3()
    {
        yield return new WaitForSeconds(1);
        End31.gameObject.SetActive(true);
        End31.enabled = true;
        End31.text = "Ah the fruits of Tactics, Wall Jumping and Disintegration";
        yield return new WaitForSeconds(3);
        End31.text = "There's only one creature who you could be!";
        yield return new WaitForSeconds(3);
        End31.gameObject.SetActive(false);
        End31.enabled = false;

        Instantiate(wolf, player.transform);
        Destroy(player);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("End 2");

    }

    public void addFruit()
    {
        fruit += 1;
    }
}
