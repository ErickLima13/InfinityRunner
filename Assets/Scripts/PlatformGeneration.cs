using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    //public List<GameObject> Platforms = new List<GameObject>();
    public GameObject Platform;
    public GameObject Coin;
    public Transform point;
    public Transform CoinPoint;
    public float minDistance;
    public float maxDistance;

    private float platformWidth;




    // Start is called before the first frame update
    void Start()
    {
        if (Platform.GetComponent<BoxCollider2D>())
        {
            platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
        }
        else
        {
            platformWidth = Platform.GetComponent<PolygonCollider2D>().bounds.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.current.PlayerIsAlive)
        {
            if (transform.position.x < point.position.x)
            {
                float Distance = Random.Range(minDistance, maxDistance);
                transform.position = new Vector3(transform.position.x + platformWidth + Distance, transform.position.y, transform.position.z);

                Instantiate(Platform, transform.position, transform.rotation);
                Instantiate(Coin, CoinPoint.transform.position, CoinPoint.transform.rotation);
            }
        }
      

    }
}
