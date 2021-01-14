using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pistola2 : MonoBehaviour
{

    public float fireRate = 0;
    private int municao = 5;
    public int dano;   
    public Transform spawnBala;
    public GameObject bala;
    ShakeCamera recuo;
    float tempoTiro;
    Text txtAk;


    public int Municao { get => municao; set => municao = value; }




    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        tempoTiro = Time.time;
        recuo= GameObject.FindGameObjectWithTag("Player02").GetComponent<ShakeCamera>();
        txtAk = GameObject.Find("municaoPistola2").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        txtAk.text = municao.ToString();

        if (fireRate == 0)
        {
            if (Input.GetButton("VERMELHO1"))
            {
             Atirar();
            }
        }
        else if (Input.GetButton("VERMELHO1") && Time.time > tempoTiro)
        {
            tempoTiro = Time.time + 1 / fireRate;
            Atirar();
        }


        if (Input.GetButton("PRETO1"))
        {
            StartCoroutine("Recarregar");   
        }

    }

    void Atirar()
    {
        if(Municao > 0)
        {
            recuo.MexendoCamera(0.01f,0.1f);
            Instantiate(bala, spawnBala.position, spawnBala.rotation);
            Municao--;            
        }
    }

    IEnumerator Recarregar ()
    {
        GetComponent<AudioSource>().Play();      
        yield return new WaitForSeconds(3f);
        Municao = 5;
    }
}
