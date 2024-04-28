using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    private int index;
    private float interval;
    Vector3 spawnPos = new Vector3(30,0,0);
    public PlayerController playerController;
     
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("Spawn",1);
    }

    // Update is called once per frame
    void Spawn()
    {
         if (!playerController.gameOver)
         {
            interval = Random.Range(1,1.8f);
            index = Random.Range(0,Obstacles.Length);
            Instantiate(Obstacles[index],spawnPos,transform.rotation);
            Invoke("Spawn",interval);
         }
    }
}
