using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f;       // 몇 초마다 생성할건지
    [SerializeField] float heightRange = 0.5f;   // 생성위치 y의 랜덤한 범위
    [SerializeField] GameObject[] pipePrefab;      // 파이프의 프리펩 연결
    [SerializeField] GameObject[] redPipePrefab;   // 빨간 파이프
    const int MAX_PIPE = 4; // 오브젝트 풀링을 위해 미리 만들어 놓을 최대 파이프 수
    int pipeIndex = 0; // 오브젝트 풀링을 위한 인덱스 저장용 변수

    float timer;

    void Update()
    {
        // 게임 상태가 PLAY일 때만 pipe 생성
        if(GameManager.Instance.GameState != GameManager.State.PLAY) return;
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
        // GameObject colorPipe = (Random.Range(0, 100) >= 10) ? pipePrefab : redPipePrefab;
        // 랜덤으로 y값을 정해서, 생성될 파이프의 위치를 정하고
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        // Instantiate로 생성, 생성된 객체는 pipe라는 GameObject에 할당
        // GameObject pipe = Instantiate(colorPipe, spawnPos, Quaternion.identity);
        // 5초 뒤에 pipe 객체 파괴
        // Destroy(pipe, 5.0f);
        
        // 오브젝트 풀링
        if(Random.Range(0, 100) > 10)
        {
            // 일반 파이프
            pipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        else
        {
            // 레드 파이프
            redPipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            redPipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        // 최대 파이프 갯수에 도달하면
        if(++pipeIndex == MAX_PIPE)
        {
            // 인덱스를 다시 0으로 시작
            pipeIndex = 0;
        }
    }
}
