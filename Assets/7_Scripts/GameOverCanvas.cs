using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] Image medal;
    [SerializeField] TMP_Text scoreResultTxt;
    [SerializeField] TMP_Text bestScoreTxt;
    [SerializeField] Sprite[] medalSprites;
    [SerializeField] Sprite nonMedalSprite;
    
    public void UpdateResult()
    {
        // 3등 안이면
        if(ScoreManager.Instance.Rank < 3)
        {
            // 메달 표시
            medal.sprite = medalSprites[ScoreManager.Instance.Rank];
        }
        else
        {
            // 메달 이미지 자체를 표시하지 않음.
            medal.sprite = nonMedalSprite;
        }
        scoreResultTxt.text = ScoreManager.Instance.Score.ToString();
        // bestScoreTxt는 최고 스코어 값을 보여준다.
    }
}
