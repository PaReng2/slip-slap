using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject bulletPrefab;
    public GameObject healBullet;
    public GameObject slowBullet;

    [Header("==")]
    public float spawnInterval = 0.5f;
    public float minRadius = 3f;     // 최소 거리
    public float maxRadius = 10f;    // 최대 거리

    [Header("roll")]
    int roll;

    private void Awake()
    {
        roll = Random.Range(0, 100);
    }
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnInterval);
    }

    void Spawn()
    {
        GameObject selectedBullet = bulletPrefab;

        float angle = Random.Range(0f, Mathf.PI * 2f);
        float radius = Random.Range(minRadius, maxRadius); // 반지름을 더 크게

        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
        Vector3 spawnPos = transform.position + offset;

        switch (roll)
        {
            case >= 80: // 85 ~ 94 (상위 5% 제외한 다음 10% 확률)
                selectedBullet = healBullet;
                break;

            case >= 75: // 70 ~ 84 (그 다음 15% 확률)
                selectedBullet = slowBullet;
                break;

            default: // 0 ~ 69 (나머지 70% 확률)
                break;
        }
        Instantiate(selectedBullet, spawnPos, Quaternion.identity);

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

