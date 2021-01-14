using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP2 : MonoBehaviour
{

    Inventario2 inventario;
    Animator animaInv;
    public GameObject itemIcone;
    bool colidiu;
    GameObject miraP2;
    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player02").GetComponent<Inventario2>();
        animaInv  = GameObject.FindGameObjectWithTag("Inv2").GetComponent<Animator>();
        miraP2 = GameObject.FindGameObjectWithTag("MiraPlayer02");

    }


    private void Update()
    {
		if (Input.GetButton("AMARELO1") && colidiu)
        {
            inventario.StartCoroutine("DesligarInv");
            for (int i = 0; i < inventario.slots.Length; i++)
            {
                if (!inventario.taCheio[i])
                {                  
                    // ADD O ITEM NO INVENTARIO AQUI
                    inventario.taCheio[i] = true;
                    Instantiate(itemIcone, inventario.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }


            }
        }
    }


    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "MiraPlayer02")
        {
            outro.GetComponent<SpriteRenderer>().color = Color.green;
            Mira2 p = outro.GetComponent<Mira2>();
            p.velocidade = 1.5f;
            StartCoroutine("Delay");
            colidiu = true;
        }
    }
    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "MiraPlayer02")
        {
            outro.GetComponent<SpriteRenderer>().color = Color.white;
            Mira2 p = outro.GetComponent<Mira2>();
            p.velocidade = 3.5f;
            StopCoroutine("Delay");
            colidiu = false;
        }
    }


    IEnumerator DesligarInv()
    {
        animaInv.SetBool("desligado", false);
        yield return new WaitForSeconds(2);
        animaInv.SetBool("desligado", true);
    }

    IEnumerator Delay()
    {
        miraP2.transform.position = transform.position;
        yield return new WaitForSeconds(2);
    }
}
