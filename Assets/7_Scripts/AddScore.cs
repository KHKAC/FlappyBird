using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] int scoreValue; // 파이프 종류 별로 얻게되는 점수 지정
    [SerializeField] AudioClip acPoint;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // "Player"라는 태그로 들어온 Trigger만 인식
        if(collision.gameObject.CompareTag("Player"))
        {
            // scoreValue 값을 실제 score에 업데이트 하는 것
            ScoreManager.Instance.UpdateScore(scoreValue);
            // 점수 획득 소리
            GameManager.Instance.PlayAudio(acPoint);
        }
    }
}
