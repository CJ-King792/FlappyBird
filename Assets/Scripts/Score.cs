using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class Score : MonoBehaviour
{
   public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _currentPointsText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;
    public int _points;
    public AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        _currentScoreText.text = _score.ToString();

        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        _currentPointsText.text = PlayerPrefs.GetInt("Points", 0).ToString();
        _points = PlayerPrefs.GetInt("Points");
        UpdatePoints();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdatePoints()
    {
        if (_score > 0 && _score % 5 == 0) {
            _points++;
            PlayerPrefs.SetInt("Points", _points);
            _currentPointsText.text = _points.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        source.Play();
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }
}