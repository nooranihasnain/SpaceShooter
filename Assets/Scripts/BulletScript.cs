using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D BulletRb;
    private float Speed = 20f;
    private ScoreManager SCM;
    //Explosion Prefab
    public GameObject ExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SCM = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        BulletRb = GetComponent<Rigidbody2D>();
        BulletRb.velocity = Vector2.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.CompareTag("Enemy"))
        {
            SCM.IncreaseScore(1);
            Destroy(Col.gameObject);
        }
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
