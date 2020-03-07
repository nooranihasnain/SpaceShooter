using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D EnemyRb;
    public float Speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        EnemyRb.velocity = Vector2.down * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
