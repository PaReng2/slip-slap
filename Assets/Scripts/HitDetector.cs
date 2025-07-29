using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public PlayerController controllerManager; // 외부에서 할당

    public enum PlayerID { Player1, Player2 }
    public PlayerID playerID;

    private bool isDead = false;

    void Update()   
    {
        if(controllerManager == null)
            controllerManager = FindObjectOfType<PlayerController>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        if (!isDead)
        {
            if (other.CompareTag("Bullet"))
            {
                isDead = true;
            
                if (controllerManager != null)
                {
                    controllerManager.HandlePlayerDeath(playerID);
                }
            
            }
            isDead = false;
        }

        
        
    }
}
