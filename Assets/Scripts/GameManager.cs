using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    [SerializeField] private GameObject tapToStart;
    [SerializeField] private GameObject logo;
    public static GameManager instance;
    public GameState currentState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        else if (instance !=this)
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (currentState != GameState.WaitingToStart) return;
        
        if (Input.GetMouseButton(0))
        {
            StateChanger(GameState.Playing);
            Time.timeScale = 1f;
            tapToStart.SetActive(false);
            logo.SetActive(false);
            
            Debug.Log(" gamemanager calisiyor");
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        StateChanger(GameState.Dead);
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    
    public enum GameState 
    {
        WaitingToStart,
        Playing, 
        Dead
    }

    public void StateChanger(GameState state)
    {
        currentState = state;
    }
}
