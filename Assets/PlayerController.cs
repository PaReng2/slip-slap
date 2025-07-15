using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Objects")]
    public GameObject XObj;
    public GameObject YObj;
    public float PlayerMoveSpeed = 5f;

    public float xMoveRange = 3f; // XObj�� ������ �� �ִ� ������
    public float yMoveRange = 3f; // YObj�� ������ �� �ִ� ������

    private Vector3 xObjStartPos;
    private Vector3 yObjStartPos;

    void Start()
    {
        // �� ������Ʈ�� �ʱ� ��ġ ����
        xObjStartPos = XObj.transform.position;
        yObjStartPos = YObj.transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // XObj �̵�
        if (moveX != 0)
        {
            Vector3 newXPos = XObj.transform.position;
            newXPos.x += moveX * PlayerMoveSpeed * Time.deltaTime;

            // ���� ��ġ  ������ Clamp
            float minX = xObjStartPos.x - xMoveRange;
            float maxX = xObjStartPos.x + xMoveRange;
            newXPos.x = Mathf.Clamp(newXPos.x, minX, maxX);

            XObj.transform.position = newXPos;
        }

        // YObj �̵�
        if (moveY != 0)
        {
            Vector3 newYPos = YObj.transform.position;
            newYPos.y += moveY * PlayerMoveSpeed * Time.deltaTime;

            float minY = yObjStartPos.y - yMoveRange;
            float maxY = yObjStartPos.y + yMoveRange;
            newYPos.y = Mathf.Clamp(newYPos.y, minY, maxY);

            YObj.transform.position = newYPos;
        }
    }
}
