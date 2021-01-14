using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AK47 : MonoBehaviour
{
    public float fireRate = 0;
    public int municao = 20;
    public int dano;
    public Transform spawnBala;
    public GameObject bala;
    Text txtAk;
    float tempoTiro;
    ShakeCamera recuo;
    // Start is called before the first frame update
    void Start()
    {
        recuo = GameObject.FindGameObjectWithTag("Player01").GetComponent<ShakeCamera>();
        txtAk = GameObject.Find("municaoAk").GetComponent<Text>();
        fireRate = 1f;
        tempoTiro = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        txtAk.text = municao.ToString();

        if (fireRate == 0)
        {
			if (Input.GetButton("VERMELHO0"))
            {
                Debug.Log("A");
                Atirar();
            }
        }
		else if (Input.GetButton("VERMELHO0") && Time.time > tempoTiro)
        {
            tempoTiro = Time.time + 0.1f / fireRate;
            Atirar();
        }


        if (Input.GetButtonDown("PRETO0"))
        {
            StartCoroutine("Recarregar");
        }

    }

    void Atirar()
    {
        if (municao > 0)
        {
            recuo.MexendoCamera(0.03f, 0.2f);
            Instantiate(bala, spawnBala.position, Quaternion.identity);
            municao -= 1;            
        }
    }

    IEnumerator Recarregar()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        municao = 20;
    }
}
