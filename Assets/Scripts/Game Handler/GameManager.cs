using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void gameStart()
    {
        Debug.Log("Game Started");
    }

    public void levelComplete()
    {
        Debug.Log("Level Completed");
    }

    private void Start()
    {
        UpdateGameState(GameState.Play);
    }

    public void gameOver()
    {
        Debug.Log("You Lose");
    }

    public void UpdateGameState(GameState newState)
    {
        switch(newState)
        {
            case GameState.Play:
                break;
            case GameState.Victory:
                break;
            case GameState.Loss:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);

    }
}

public enum GameState
{
    Play,
    Victory,
    Loss
}
