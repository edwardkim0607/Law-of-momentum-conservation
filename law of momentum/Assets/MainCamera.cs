using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float speed = 100.0f; // ī�޶� �̵� �ӵ�

    void Update()
    {
        // WASD �Է��� �޾� �̵� ���� ����
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Q, E �Է��� �޾� ���� �̵� ���� ����
        float moveUp = 0.0f;
        if (Input.GetKey(KeyCode.Q))
        {
            moveUp = 5.0f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveUp = -5.0f;
        }

        // ��ü �̵� ���� ����
        Vector3 movement = new Vector3(speed*moveHorizontal, moveUp,speed* moveVertical);

        // ī�޶� �̵�
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
