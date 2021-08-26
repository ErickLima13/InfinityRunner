using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private GameObject player;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.current.PlayerIsAlive)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x + 6f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, Speed * Time.deltaTime);
        }
        


    }
}
