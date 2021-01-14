using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2Sniper : MonoBehaviour
{
	ControlandoArma goControladorArmas;
	Inventario2 inventario;    
	private void Start()
	{

		inventario = GameObject.FindGameObjectWithTag("Player02").GetComponent<Inventario2>();
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
						goControladorArmas.tipoArma = 8;

                    }
                }
                else
                {
                    goControladorArmas.tipoArma = 9;
                }
            }           
		}

	}  
}
