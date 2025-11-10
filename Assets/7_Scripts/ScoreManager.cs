using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TMP_Text scoreTxt;
    int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Update()
    {
        scoreTxt.text = score.ToString();
    }

    public void UpdateScore()
    {
        score++;
    }
}
