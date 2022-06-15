using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject restartCanvas;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    public bool IsGameActive { get; private set; } = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IsGameActive = true;
        restartCanvas.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("You Lose");
        IsGameActive = false;
        restartCanvas.SetActive(true);
        loseUI.SetActive(true);
        winUI.SetActive(false);
    }

    public void GameWin()
    {
        Debug.Log("You Win");
        IsGameActive = false;
        restartCanvas.SetActive(true);
        loseUI.SetActive(false);
        winUI.SetActive(true);
    }
}