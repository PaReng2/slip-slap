using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Objects")]
    public GameObject Player1Obj;
    public GameObject Player2Obj;
    public float PlayerMoveSpeed = 5f;

    public float xMoveRange = 3f;

    [Header("Dath Effect")]
    public ParticleSystem p1DathEffect;
    public ParticleSystem p2DathEffect;

    [Header("Debuff")] 
    public bool slowP1;
    public bool slowP2;
        
    private Vector3 Player1ObjStartPos;
    private Vector3 Player2ObjStartPos;

    private bool  isDead =  false;

    void Start()
    {
        slowP1 = false;
        slowP2 = false;
        
        Player1ObjStartPos = Player1Obj.transform.position;
        Player2ObjStartPos = Player2Obj.transform.position;
    }

    void Update()
    {

        Move();
    }

    void Move()
    {
        // === Player1Obj: A / D Ű�� X�� �̵� ===
        float moveX1 = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveX1 = slowP1 ? -0.5f : -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX1 = slowP1 ? 0.5f : 1f;
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

        // === Player2Obj: �¿� ����Ű�� X�� �̵� ===
        float moveX2 = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX2 = slowP2 ? -0.5f : -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX2 = slowP2 ? 0.5f : 1f;
        }

        if (moveX2 != 0)
        {
            Vector3 newXPos = Player2Obj.transform.position;    //�ʱ� ��ġ��
            newXPos.x += moveX2 * PlayerMoveSpeed * Time.deltaTime;     //x������ �̵�

            float minX = Player2ObjStartPos.x - xMoveRange;     
            float maxX = Player2ObjStartPos.x + xMoveRange;
            newXPos.x = Mathf.Clamp(newXPos.x, minX, maxX);     //���� �÷��̾� ��ġ +- �Ͽ� �̵� ���� ����

            Player2Obj.transform.position = newXPos;
        }
    }

    public void HandlePlayerDeath(HitDetector.PlayerID id)
    {
        GameManager manager = FindAnyObjectByType<GameManager>();
        if (id == HitDetector.PlayerID.Player1)
        {
            manager.secondPoint += 1;
            manager.isDathP1 = true;
            p1DathEffect.Play();
            Debug.Log("Player1 die");
        }
        else if (id == HitDetector.PlayerID.Player2)
        {
            manager.firstPoint += 1;
            manager.isDathP2 = true;
            p2DathEffect.Play();
            Debug.Log("Player2 die");
        }
    }

}
