using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{

    Inventario inventario;
    Animator animaInv;
    public GameObject itemIcone;
    bool colidiu;
    GameObject miraP1;

    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player01").GetComponent<Inventario>();
        animaInv  = GameObject.FindGameObjectWithTag("Inv").GetComponent<Animator>();
        miraP1 = GameObject.FindGameObjectWithTag("MiraPlayer01");
    }


    private void Update()
    {
		if (Input.GetButton("AMARELO0") && colidiu)
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
        if (outro.gameObject.tag == "MiraPlayer01")
        {
            outro.GetComponent<SpriteRenderer>().color = Color.green;
            outro.transform.position = transform.position;
            Mira p = outro.GetComponent<Mira>();
            p.velocidade = 1.5f;
            StartCoroutine("Delay");
            colidiu = true;
        }

    }
    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "MiraPlayer01")
        {
            outro.GetComponent<SpriteRenderer>().color = Color.white;
            Mira p = outro.GetComponent<Mira>();
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
        miraP1.transform.position = transform.position;
        yield return new WaitForSeconds(2);
    }


}
