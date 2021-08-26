using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 3;
    public Image Life;
    public Image Life2;
    public Image Life3;
    public float Speed;
    public float JumpForce;
    public GameObject Smoke;
    public GameObject Bullet;
    public Transform FirePoint;

    private bool isJumping;
    private Rigidbody2D Rig;


    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Movimenta o Player para frente (Direita)
        Rig.velocity = new Vector2(Speed * Time.deltaTime, Rig.velocity.y);

        //Pular
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isJumping = true;
            Smoke.SetActive(true);
        }

        //Atirar
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;
            Smoke.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            GameController.current.AddScore(5);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {

            print("bateu");
            if(health <= 3)
            {
                Life.enabled = false;
                
            }
            
            
            if(health == 2)
            {
                Life2.enabled = false;
                
            }

            if(health == 1)
            {
                Life3.enabled = false;
                
            }

            health -= 1;
            if (health == 0)
            {
                GameController.current.GameOverPanel.SetActive(true);
                GameController.current.PlayerIsAlive = false;
                Destroy(gameObject);
            }

        }
    }

    public void JumpBt()
    {
        if (!isJumping)
        {
            Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isJumping = true;
            Smoke.SetActive(true);
        }
    }

    public void Fire()
    {
        Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);
    }
}
