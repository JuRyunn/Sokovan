using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // float speed= 10f; (���������� private ó���� �ȴ�.
    // ��[ private float speed= 10f; ] )
    public float speed = 10f; 
    public Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // ������⿡ ���� Ű���� �Է��� -1 ~ +1 ���� �ش�.
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        
        velocity = velocity * speed;
        velocity.y = fallSpeed;

        playerRigidbody.velocity= velocity;
    }
}
