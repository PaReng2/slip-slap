using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealBullet : MonoBehaviour
{
    public BulletSO bulletData;
    private PlayerController pc;
    bulletType type;

    private void Awake()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("P1"))
        {
            pc.slowP1 = false;  //디버프 해제

            Destroy(gameObject);

        }


        if (other.CompareTag("P2"))
        {
            pc.slowP2 = false;
            Destroy(gameObject);
        }


    }
}
