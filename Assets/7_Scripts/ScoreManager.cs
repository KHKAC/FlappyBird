using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TMP_Text scoreTxt;
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
}
