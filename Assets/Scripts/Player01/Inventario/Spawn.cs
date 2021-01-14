using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject item;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player01").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + (-0.4f));
        Instantiate(item, playerPos, Quaternion.identity);
    }

}
