using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameSession;

    public TextMeshProUGUI ScoreText { get => scoreText; set => scoreText = value; }

  
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        ScoreText.text = gameSession.Score.ToString();
    }
}
