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
        score = 0;

    }


    void Update()
    {

        Health.text = ("Health = " + score.ToString());

    }

    public void AddScore()
    {
        score += 1;

    }
    public void MinusScore()
    {
        score -= 3;

    }
}
