using System.Collections;
using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    public BulletSO bulletData;
    private PlayerController player;
    public float slowDuration; // 느려지는 시간(초)

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        slowDuration = bulletData.debuffAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("P1"))
        {
            StartCoroutine(ApplySlowToP2());
            Destroy(gameObject);
        }
        else if (other.CompareTag("P2"))
        {
            StartCoroutine(ApplySlowToP1());
            Destroy(gameObject);
        }
    }

    private IEnumerator ApplySlowToP1()
    {
        player.slowP1 = true;
        yield return new WaitForSeconds(slowDuration);
        player.slowP1 = false;
    }

    private IEnumerator ApplySlowToP2()
    {
        player.slowP2 = true;
        yield return new WaitForSeconds(slowDuration);
        player.slowP2 = false;
    }
}