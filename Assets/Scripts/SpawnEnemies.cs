using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float initialTime;
    public float minTime;
    public float maxTime;
    public List<GameObject> EnemiesList = new List<GameObject>();

    private float timeControl;
   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeControl += Time.deltaTime;

        if (GameController.current.PlayerIsAlive)
        {
            if (timeControl >= initialTime)
            {
                Instantiate(EnemiesList[Random.Range(0, EnemiesList.Count)], transform.position + new Vector3(0, Random.Range(-2, 3), 0), transform.rotation);

                initialTime = Random.Range(minTime, maxTime);
                timeControl = 0;
            }
        }
        

    }

    
}
