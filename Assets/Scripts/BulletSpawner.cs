using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Prefab")]
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

     }

    // Update is called once per frame
    void Update()
      {
        
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            dathTime = Random.Range(2f, 5f);
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);  

            // ���� ������ bullet�� Rigidbody ��������
            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)   //������ ��ġ���� �̾Ƽ� ��Ѹ���
                {
                Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized; 
                bulletRb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
                }

            spawnRate = Random.Range(minSpawnTime, maxSpawnTime);   //���� ���� ����

            Destroy(newBullet, dathTime);   //�ν��Ͻ�ȭ�Ͽ� ���� ������ ������Ʈ�� �ı� (�ܿ�����)
        }

      }

}
