using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject bulletPrefab;

    public GameObject SlowBullet;

    public float spawnInterval = 0.5f;
    public float minRadius = 3f;     // 최소 거리
    public float maxRadius = 10f;    // 최대 거리
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnInterval);
    }

    void Spawn()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float radius = Random.Range(minRadius, maxRadius); // 반지름을 더 크게

        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
        Vector3 spawnPos = transform.position + offset; //양심고백 GPT가 계산해줬읍미다 ㅠㅠ 이건 너무 어렵자나요

        if (Random.Range(1, 10) == 5)
            Instantiate(SlowBullet, spawnPos, Quaternion.identity);
        else
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawn()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager.isScoring)
        {
            CancelInvoke(nameof(Spawn)); // 점수 애니메이션 중이면 멈춰
        }
        else if (!IsInvoking(nameof(Spawn)))
        {
            InvokeRepeating(nameof(Spawn), 0f, spawnInterval); // 안 돌고 있으면 다시 시작
        }
    }
}

