using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject verPlayer;
    public GameObject horPlayer;

    public GameObject verSlideBar;
    public GameObject horSlideBar;
    public GameObject enemyPrefab;

    [Header("Player Stat")]
    public int playerMoveSpeed = 5;

    private bool isMoveHor;
    private bool isMoveVer;

    void Start()
    {
        isMoveHor = true;
        isMoveVer = true;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
       if (Input.GetKey(KeyCode.A) && isMoveHor == true)
        {
            horPlayer.transform.Translate(-playerMoveSpeed * Time.deltaTime, 0, 0);
        }

       if (Input.GetKey(KeyCode.D) && isMoveHor == true)
        {
            horPlayer.transform.Translate(playerMoveSpeed * Time.deltaTime, 0, 0);
        }

      if (Input.GetKey(KeyCode.UpArrow) && isMoveVer == true)
       {
            verPlayer.transform.Translate(0, playerMoveSpeed * Time.deltaTime, 0);
       }

      if (Input.GetKey(KeyCode.DownArrow) && isMoveVer == true)
        {
            verPlayer.transform.Translate(0, -playerMoveSpeed * Time.deltaTime, 0);
        }
      
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "bounHor")
    //    {
    //        isMoveHor = false;
    //    }
    //    else
    //    {
    //        isMoveHor = true;
    //    }

    //    if (collision.tag == "bounVer")
    //    {
    //        isMoveVer = false;
    //    }
    //    else
    //    {
    //        isMoveVer = true;
    //    }

    //}

}
