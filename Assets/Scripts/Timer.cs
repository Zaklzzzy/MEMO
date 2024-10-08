﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _gameDuration;
    [Header("Lose")]
    [SerializeField] private GameObject _loseText;
    [SerializeField] private GameObject _menuButton;

    private float _timeRemaining;

    private void Start()
    {
        // Init timer
        _timeRemaining = _gameDuration;
        StartCoroutine(GameTimer());
    }
    private IEnumerator GameTimer()
    {
        while (_timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            _timeRemaining--;

            UpdateTimerText(_timeRemaining);

            if (_timeRemaining <= 0)
            {
                _menuButton.SetActive(false);
                _loseText.SetActive(true);
                Invoke("Lose", 1.25f);
            }
        }
    }
    private void UpdateTimerText(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Lose()
    {
        SceneManager.LoadScene("StartMenu");
    }

}