using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public const int MAX_RANK = 5; // 최대 랭크 보여줄 개수
    // DateTime을 string 형식으로 바꿀 때 쓸 패턴
    public static string DTPattern = @"yyMMddhhmmss";
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] GameOverCanvas gameOverCanvas;
    int score = 0;
    int rank = 0;
    public int Score => score;
    public int Rank => rank;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void UpdateScore(int val)
    {
        score += val;
        scoreTxt.text = score.ToString();
    }

    public void CheckBestScore()
    {
        // 현재 저장된 1에서 5등까지의 순위값을 Dictionary를 사용해서 저장
        var rankDic = new Dictionary<string, int>();
        for (int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"25111712000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            rankDic.Add(key, value);
        }
        // 현재 일시를 패턴을 이용해 키값으로 만들고
        string nowKey = DateTime.Now.ToString(DTPattern);
        // Dictionary에 저장 -> 총 개수가 MAX_RANK + 1;
        rankDic.Add(nowKey, score);
        // 내침차순으로 정렬한 값을 새로운 Dictionary에 저장
        var newDic = rankDic.OrderByDescending(x => x.Value);
        // 랭크값으로 최대값을 설정
        rank = MAX_RANK;
        // Index는 0으로 시작
        int index = 0;
        foreach(var item in newDic)
        {
            // 1~5등까지의 값을 저장
            PlayerPrefs.SetString($"RANKDATE{index}", item.Key);
            PlayerPrefs.SetInt($"RANKSCORE{index}", item.Value);
            // 현재 item이 nowKey값과 같으면 그 때 인덱스가 랭크 값
            if(item.Key.Equals(nowKey))
            {
                rank = index;
            }
            //최대 랭크 수만큼 돌았으면 나가기
            if(++index == MAX_RANK) break;
        }
        // GameOverCanvas를 업데이트
        gameOverCanvas.UpdateResult();
    }

    // 베스트 스코어 리셋
#if UNITY_EDITOR
    [MenuItem("FlappyBird/Reset Best Score")]
    public static void ResetBestScore()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Reset best Score...done");
    }
#endif
}
