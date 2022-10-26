using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI Start1;
    public TextMeshProUGUI Start2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Begin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Begin()
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
    }
}
