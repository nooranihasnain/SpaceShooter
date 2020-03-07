using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //Movement
    public float Speed = 20f;
    private Rigidbody2D PlayerRb;
    
    //Bullet
    public Transform FireSocket;
    public GameObject BulletPrefab;

    //Lives Manager
    private LivesManager LM;

    //GameoverScreenPrefab
    public GameObject GameoverPrefab;

    //Animator
    private Animator PlayerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        LM = GameObject.FindWithTag("LivesManager").GetComponent<LivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //keyboard control
        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            float HozAxis = Input.GetAxis("Horizontal");
            float VerAxis = Input.GetAxis("Vertical");
            Vector2 Direction = new Vector2(HozAxis, VerAxis);
            PlayerRb.velocity = Direction * Speed * Time.deltaTime;
        }
        //Accelerometer controls
        else
        {
            Vector2 Direction = new Vector2(Input.acceleration.x, 0f);
            PlayerRb.velocity = Direction * Speed * Time.deltaTime;
        }

        //Limiting movement inside the box
        PlayerRb.position = new Vector2(Mathf.Clamp(PlayerRb.position.x, -2f, 2f), Mathf.Clamp(PlayerRb.position.y, -4f, 3f));
    }

    void Shoot()
    {
        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BulletPrefab, FireSocket.position, Quaternion.identity);
            }
        }
        else
        {
            foreach(Touch t in Input.touches)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Instantiate(BulletPrefab, FireSocket.position, Quaternion.identity);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.CompareTag("Enemy"))
        {
            Destroy(Col.gameObject);
            LM.DecrementLives();
            PlayerAnimator.Play("Hit");
            if(LM.GetLives() == 0)
            {
                GameObject GOScreen = Instantiate(GameoverPrefab, Vector3.zero, Quaternion.identity);
                GOScreen.transform.SetParent(GameObject.Find("Canvas").transform, false);
                gameObject.SetActive(false);
            }
        }
    }
}
