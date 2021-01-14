using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot2 : MonoBehaviour
{

    private Inventario2 inventario;
    public int I;

    private void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player02").GetComponent<Inventario2>();
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
