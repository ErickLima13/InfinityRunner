using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;

    private Transform BackPoint;
    private Animator anim;
    private Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        BackPoint = GameObject.Find("BackPoint").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.current.PlayerIsAlive)
        {
            float Speed = Random.Range(5, 15);
            rig.velocity = new Vector2(-Speed, rig.velocity.y);

            if (transform.position.x < BackPoint.position.x)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GameController.current.AddScore(10);
            anim.SetTrigger("destroy");
            Destroy(gameObject, 0.5f);
        }
    }
}
