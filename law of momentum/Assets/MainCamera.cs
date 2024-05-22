using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float speed = 100.0f; // 카메라 이동 속도

    void Update()
    {
        // WASD 입력을 받아 이동 벡터 생성
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Q, E 입력을 받아 수직 이동 벡터 생성
        float moveUp = 0.0f;
        if (Input.GetKey(KeyCode.Q))
        {
            moveUp = 5.0f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveUp = -5.0f;
        }

        // 전체 이동 벡터 생성
        Vector3 movement = new Vector3(speed*moveHorizontal, moveUp,speed* moveVertical);

        // 카메라 이동
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
