using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore(int score, int collected, int totalItems)
    { 
        //Removed displaying totalItems to avoid confusion as collectables can respawn now
        this.scoreText.text = string.Format("Score: {0}\nCollected:{1}", score, collected, totalItems);
    }
    public void SetTime(float time)
    {
        this.timeText.text = string.Format("{0:0}", time);
    }
}
