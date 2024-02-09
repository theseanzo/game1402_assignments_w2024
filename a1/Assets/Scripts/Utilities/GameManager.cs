using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _score;
    private Food[] foods;
    private int numberCollected = 0;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            numberCollected++;
            UIManager.Instance.SetScore(_score, numberCollected, foods.Length);
        }
    }

    public float GameTime { get; private set; }

    void Start()
    {
        GameTime = 0;
        foods = FindObjectsOfType<Food>();
    }

    void Update()
    {
        if (IsGameRunning())
            GameTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (IsGameRunning())
            UIManager.Instance.SetTime(GameTime);
    }

    bool IsGameRunning()
    {
        // Add conditions to check if the game is running or not
        return true;
    }

    public void RespawnFood(Food food)
    {
        StartCoroutine(RespawnFoodCoroutine(food));
    }

    IEnumerator RespawnFoodCoroutine(Food food)
    {
        food.gameObject.SetActive(false);
        yield return new WaitForSeconds(GameConstants.RespawnTime);
        food.gameObject.SetActive(true);
    }
}
