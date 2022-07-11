using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // float speed= 10f; (郴何利栏肺 private 贸府啊 等促. -> [ private float speed= 10f; ] )
    public float speed = 10f; 
    public Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody.AddForce(0, 1000, 0);
    }

    
    void Update()
    {
        
    }
}
