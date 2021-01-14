using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public bool[] taCheio;
    public bool[] selecionado;
    public GameObject[] slots;
    public GameObject[] slotsSelecionado;
    public Animator inventario;
    Player player01;
    int slotAtual;

    private void Start()
    {
       inventario.SetBool("desligado", true);
       player01 = GameObject.FindGameObjectWithTag("Player01").GetComponent<Player>();
    }
    private void Update()
    {
        
        

		if (Input.GetButtonDown("BRANCO0") && !player01.andando)
        {           
            ProximoSlot();
            StartCoroutine("DesligarInv");
        }
    }
    void ProximoSlot()
    {
        if (slotAtual == 0)
        {
            slotsSelecionado[slotAtual].SetActive(true);
        }
        else if (slotAtual < slotsSelecionado.Length)
        {
            
            slotsSelecionado[slotAtual - 1].SetActive(false);

            slotsSelecionado[slotAtual].SetActive(true);
        }else if (slotAtual == slotsSelecionado.Length)
        {
            slotsSelecionado[slotAtual - 1].SetActive(false);
        }


        //Aumentando o Slot At
        if(slotAtual < slotsSelecionado.Length)
        {
            slotAtual++;
        }else if (slotAtual == slotsSelecionado.Length)
        {
            slotAtual -= slotsSelecionado.Length;
        }
    }

  public IEnumerator DesligarInv()
    {
        inventario.SetBool("desligado",false);
        yield return new WaitForSeconds(2);
        inventario.SetBool("desligado", true);
    }
}
