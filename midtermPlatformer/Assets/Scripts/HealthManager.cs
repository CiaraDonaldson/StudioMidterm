using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int score = 0;
    
    public TextMeshProUGUI Health;



    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
       

    }


    void Update()
    {

        Health.text = ("Health: " + score.ToString());

    }

    public void AddScore()
    {
        score += 1;

    }
    public void MinusScore()
    {
        score -= 3;

    }
    public void Reset()
    {
        score = 0;
    }
}
