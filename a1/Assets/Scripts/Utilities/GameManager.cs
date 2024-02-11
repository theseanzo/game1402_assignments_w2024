using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public static GameManager instance;
    private int _score;
    private Foodd[] foods;
    private int numberCollected = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            numberCollected += value >= 0 ? 1 : 0;

            UIManager.Instance.SetScore(_score, numberCollected, foods.Length);
        }
    }
    public float GameTime
    {
        get; private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameTime = 0;
        foods = FindObjectsOfType<Foodd>();
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        UIManager.Instance.SetTime(GameTime);
    }



}
