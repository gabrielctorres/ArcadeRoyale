using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPistola : MonoBehaviour
{
   ControlandoArma goControladorArmas;
    Inventario inventario;    
    private void Start()
    {

        inventario = GameObject.FindGameObjectWithTag("Player01").GetComponent<Inventario>();
       goControladorArmas = GameObject.FindGameObjectWithTag("Controlador").GetComponent<ControlandoArma>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inventario.slotsSelecionado.Length; i++)
        {
            if (inventario.slotsSelecionado[i].activeInHierarchy)
            {
                if (inventario.slotsSelecionado[i] == inventario.taCheio[i])
                {                    
                    if (this.transform.IsChildOf(inventario.slots[i].transform))
                    {                       
                        goControladorArmas.tipoArma = 1;                        

                    }
                }
                else
                {
                    goControladorArmas.tipoArma = 0;
                }
            }           
        }

    }  
}

