using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // configuration parameters
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsAdded = 20;
    [SerializeField] TextMeshProUGUI scoreText;


    // state variables
    [SerializeField] int currentScore = 0;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsAdded;
        scoreText.text = currentScore.ToString();
    }
}
