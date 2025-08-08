using System.Collections;
using UnityEngine;

public class EffectBullet : MonoBehaviour
{
    private PlayerController player;
    public float slowDuration = 5f; // 느려지는 시간(초)

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
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
        player.frozenP1 = true;
        yield return new WaitForSeconds(slowDuration);
        player.frozenP1 = false;
    }

    private IEnumerator ApplySlowToP2()
    {
        player.frozenP2 = true;
        yield return new WaitForSeconds(slowDuration);
        player.frozenP2 = false;
    }
}