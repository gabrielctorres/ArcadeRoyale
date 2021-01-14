using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootGun2 : MonoBehaviour
{
    public float fireRate = 0;
    public int municao = 8;
    public int dano;
    public Transform spawnBala;
    public Transform spawnBala2;
    public Transform spawnBala3;
    public GameObject bala;
    float tempoTiro;
    Text txtAk;

    ShakeCamera recuo;
   
    // Start is called before the first frame update
    void Start()
    {
        recuo = GameObject.FindGameObjectWithTag("Player02").GetComponent<ShakeCamera>();
        txtAk = GameObject.Find("municao122").GetComponent<Text>();
        fireRate = 1f;
        tempoTiro = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        txtAk.text = municao.ToString();

        if (fireRate == 0)
        {
            if (Input.GetButton("VERMELHO1"))
            {
                Debug.Log("A");
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
        if (municao > 0)
        {
         recuo.MexendoCamera(0.03f, 0.2f);
         Instantiate(bala, spawnBala.position,Quaternion.identity);
         Instantiate(bala, spawnBala2.position,Quaternion.identity);
         Instantiate(bala, spawnBala3.position,Quaternion.identity);
         municao -= 3;
          Debug.Log("Munição restante " + municao);
        }
    }

    IEnumerator Recarregar()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        municao = 9;
    }
}
