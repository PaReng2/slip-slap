using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject player1;
    public GameObject player2;
    public GameObject bulletPrefab;

    public float minSpawnTime;
    public float maxSpawnTime;

    private float bounceForce;
    private float dathTime;

    private float spawnRate;
    private float timeAfterSpawn;
    private Transform target;

    // Start is called before the first frame update
    void Start()
     {
        bounceForce = Random.Range(10f, 30f);
        
        target = FindObjectOfType<PlayerController>().transform;
        spawnRate = Random.Range(minSpawnTime, maxSpawnTime);
        timeAfterSpawn = 0f;
        PlayerController player = FindAnyObjectByType<PlayerController>();
     }

    // Update is called once per frame
    void Update()
      {
        
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            dathTime = Random.Range(1f, 5f);
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 새로 생성된 bullet의 Rigidbody 가져오기
            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
                {
                bulletRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                Debug.Log("통");
                }

            spawnRate = Random.Range(minSpawnTime, maxSpawnTime);

            Destroy(newBullet, dathTime);
        }

      }

}
