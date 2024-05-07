using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu = 1,
        Playing = 2,
        GameOver = 3,
        Paused = 4,
    }

    public GameState CurrentState { get; private set; }
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene((int)GameState.Menu);
        CurrentState = GameState.Menu;
        AudioManager.Instance.PlayMusic("MenuMusic");
    }

    public void GameStart()
    {
        // Здесь может быть код, который подготавливает игру к началу
        // Например, установка начального счета, позиции игрока и т.д.
        // Затем переходим в состояние Playing
        SceneManager.LoadScene((int)GameState.Playing);
        CurrentState = GameState.Playing;
        AudioManager.Instance.PlayMusic("GameMusic");
    }

    public void PauseGame()
    {
        if (CurrentState == GameState.Playing)
        {
            // Здесь может быть код, который ставит игру на паузу
            // Например, остановка времени в игре
            CurrentState = GameState.Paused;
        }
    }

    public void ResumeGame()
    {
        if (CurrentState == GameState.Paused)
        {
            // Здесь может быть код, который возобновляет игру
            // Например, возобновление времени в игре
            CurrentState = GameState.Playing;
        }
    }

    public void EndGame()
    {
        if (CurrentState == GameState.Playing)
        {
            // Здесь может быть код, который обрабатывает окончание игры
            // Например, показ экрана Game Over, сохранение счета и т.д.
            SceneManager.LoadScene((int)GameState.GameOver);
            CurrentState = GameState.GameOver;
            AudioManager.Instance.PlayMusic("EndGameMusic");
        }
    }
}
