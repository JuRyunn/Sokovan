using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // float speed= 10f; (내부적으로 private 처리가 된다.
    // └[ private float speed= 10f; ] )
    public float speed = 10f; 
    public Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // 수평방향에 대해 키보드 입력을 -1 ~ +1 값을 준다.
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        
        velocity = velocity * speed;
        velocity.y = fallSpeed;

        playerRigidbody.velocity= velocity;
    }
}
