using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject[] spawnPoints;  
    public GameObject player01;
    public GameObject MiraP01,MiraP02;
    public GameObject player02;


    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0,spawnPoints.Length);        
        player01.transform.position = spawnPoints[index].transform.position;
        MiraP01.transform.position = player01.transform.position;

        int index2 = Random.Range(0, spawnPoints.Length);
        player02.transform.position = spawnPoints[index2].transform.position;
        MiraP02.transform.position = player02.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
