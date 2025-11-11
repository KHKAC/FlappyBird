using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f;       // 몇 초마다 생성할건지
    [SerializeField] float heightRange = 0.5f;   // 생성위치 y의 랜덤한 범위
    [SerializeField] GameObject pipePrefab;      // 파이프의 프리펩 연결
    [SerializeField] GameObject redPipePrefab;   // 빨간 파이프

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            SpawnPipe();
            timer = 0.0f;
        }
    }
    
    void SpawnPipe()
    {
        // 랜덤으로 녹색인지 빨간색인지 파이프 선택
        GameObject colorPipe = (Random.Range(0, 100) >= 10) ? pipePrefab : redPipePrefab;
        // 랜덤으로 y값을 정해서, 생성될 파이프의 위치를 정하고
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        // Instantiate로 생성, 생성된 객체는 pipe라는 GameObject에 할당
        GameObject pipe = Instantiate(colorPipe, spawnPos, Quaternion.identity);
        // 5초 뒤에 pipe 객체 파괴
        Destroy(pipe, 5.0f);
    }
}
