using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class RankUI : MonoBehaviour
{
    [SerializeField] Image medal;
    [SerializeField] TMP_Text rankTxt;
    [SerializeField] TMP_Text dateTxt;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] Sprite[] medalSprite;
    
    public void SetRank(int rank, int score, string dt)
    {
        // 랭크가 3 이상이면 3을 아니면 그 값을 인덱스로 한다.
        int medalIndex = (rank > 2) ? 3 : rank;
        // 메달스프라이트에 있는 메달 이미지를 선택
        medal.sprite = medalSprite[medalIndex];
        // 랭크 값은 0부터이므로 +1을 해줘야 함.
        rankTxt.text = (rank + 1).ToString();
        // 랭크가 3 이상일 때만 표시
        rankTxt.gameObject.SetActive(rank > 2);

        // string연산을 많이 하게 될 것 같음 -> StringBuilder 사용
        // "251117132704" -> "2025/11/17(줄바꿈)13:27:04"
        var sb = new StringBuilder();
        sb.Append("20");
        sb.Append(dt.Substring(0, 2));
        sb.Append("/");
        sb.Append(dt.Substring(2, 2));
        sb.Append("/");
        sb.Append(dt.Substring(4, 2));
        sb.Append("\n");
        sb.Append(dt.Substring(6, 2));
        sb.Append(":");
        sb.Append(dt.Substring(8, 2));
        sb.Append(":");
        sb.Append(dt.Substring(10, 2));
        // StringBuilder에서 값을 넘길 때는 string을 잊지 말 것.
        dateTxt.text = sb.ToString();

        // 점수 표시
        scoreTxt.text = score.ToString();
    }
}
