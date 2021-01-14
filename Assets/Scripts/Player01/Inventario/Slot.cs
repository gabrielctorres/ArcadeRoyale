using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    private Inventario inventario;
    public int I;

    private void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player01").GetComponent<Inventario>();
    }

    private void Update()
    {
        if (transform.childCount <=0)
        {
            inventario.taCheio[I] = false;
        } 
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }



}
