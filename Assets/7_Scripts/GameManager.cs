using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임의 상태를 저장할 enum
    public enum State
    {
        TITLE,      // 0 : 0
        READY,      // 1 : 0
        PLAY,       // 2 : 0
        GAMEOVER,   // 3 : 1
        BESTSCORE   // 4 : 1
    }
    public static GameManager Instance;
    [SerializeField] SpriteRenderer background;
    [SerializeField] GameObject[] stateUI;
    [SerializeField] Sprite[] bgSprite;
    [SerializeField] Animator floorAnim;
    State gameState;    // 게임 상태를 저장할 함수
    public State GameState => gameState;

    void Awake()
    {
        if (Instance == null) Instance = this;
        
    }

    void Start()
    {
        GameTitle();
        Time.timeScale = 1.0f;
    }

    void ChangeState(State value)
    {
        gameState = value;
        // stateUI에 있는 모든 UI를 끈다.
        foreach(var item in stateUI)
        {
            item.SetActive(false);
        }
        // State값을 공통으로 사용하므로 미리 int값으로 변환
        int temp = (int)gameState;
        // 해당하는 Background sprite 연결
        background.sprite = bgSprite[temp > 2 ? 1 : 0];
        stateUI[temp].SetActive(true);
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
        // 게임 시간을 멈춘다.
        // Time.timeScale = 0f;
        floorAnim.enabled = false;
    }

    public void GameBestScore() => ChangeState(State.BESTSCORE);

    // 현재 씬을 다시 불러오기
    public void OnRetryBtn() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
