using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임의 상태를 저장할 enum
    public enum State
    {
        TITLE,      // 0
        READY,      // 1
        PLAY,       // 2
        GAMEOVER,   // 3
        BESTSCORE   // 4
    }
    public static GameManager Instance;
    [SerializeField] GameObject gameOverUI;
    State gameState;    // 게임 상태를 저장할 함수
    public State GameState => gameState;

    void Awake()
    {
        if (Instance == null) Instance = this;
        
    }

    void Start()
    {
        GameReady();
        Time.timeScale = 1.0f;
    }

    void ChangeState(State value)
    {
        gameState = value;
    }

    public void GameTitle() => ChangeState(State.TITLE);

    public void GameReady()
    {
        ChangeState(State.READY);
    }

    public void GamePlay() => ChangeState(State.PLAY);

    public void GameOver()
    {
        ChangeState(State.GAMEOVER);
        gameOverUI.SetActive(true);
        // 게임 시간을 멈춘다.
        Time.timeScale = 0f;
    }

    public void GameBestScore() => ChangeState(State.BESTSCORE);

    // 현재 씬을 다시 불러오기
    public void OnRetryBtn() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
