using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Objects")]
    public GameObject Player1Obj;
    public GameObject Player2Obj;
    public float PlayerMoveSpeed = 5f;

    public float xMoveRange = 3f; // XObj가 움직일 수 있는 범위
    public float yMoveRange = 3f; // YObj가 움직일 수 있는 범위

    private Vector3 Player1ObjStartPos;
    private Vector3 Player2ObjStartPos;

    private bool  isDead =  false;

    void Start()
    {
        // 각 오브젝트의 초기 위치 저장
        Player1ObjStartPos = Player1Obj.transform.position;
        Player2ObjStartPos = Player2Obj.transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // === Player1Obj: A / D 키로 X축 이동 ===
        float moveX1 = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveX1 = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX1 = 1f;
        }

        if (moveX1 != 0)
        {
            Vector3 newXPos = Player1Obj.transform.position;
            newXPos.x += moveX1 * PlayerMoveSpeed * Time.deltaTime;

            float minX = Player1ObjStartPos.x - xMoveRange;
            float maxX = Player1ObjStartPos.x + xMoveRange;
            newXPos.x = Mathf.Clamp(newXPos.x, minX, maxX);

            Player1Obj.transform.position = newXPos;
        }

        // === Player2Obj: 좌우 방향키로 X축 이동 ===
        float moveX2 = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX2 = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX2 = 1f;
        }

        if (moveX2 != 0)
        {
            Vector3 newXPos = Player2Obj.transform.position;    //초기 위치값
            newXPos.x += moveX2 * PlayerMoveSpeed * Time.deltaTime;     //x축으로 이동

            float minX = Player2ObjStartPos.x - xMoveRange;     
            float maxX = Player2ObjStartPos.x + xMoveRange;
            newXPos.x = Mathf.Clamp(newXPos.x, minX, maxX);     //현재 플레이어 위치 +- 하여 이동 범위 설정

            Player2Obj.transform.position = newXPos;
        }
    }

    public void HandlePlayerDeath(HitDetector.PlayerID id)
    {
        GameManager manager = FindAnyObjectByType<GameManager>();
        if (id == HitDetector.PlayerID.Player1)
        {
            Player1Obj.SetActive(false); // 또는 애니메이션/연출
            manager.firstPoint += 1;
            Debug.Log("Player1 사망");
        }
        else if (id == HitDetector.PlayerID.Player2)
        {
            Player2Obj.SetActive(false);
            manager.secondPoint += 1;
            Debug.Log("Player2 사망");
        }

        
    }

}
