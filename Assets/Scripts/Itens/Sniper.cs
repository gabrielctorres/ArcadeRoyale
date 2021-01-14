using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
	public float fireRate = 0;
	public int municao = 1;
	public int dano;
	public Transform spawnBala;
	public GameObject bala;    
	float tempoTiro;
    Text txtAk;
    ShakeCamera recuo;
	// Start is called before the first frame update
	void Start()
	{
		recuo = GameObject.FindGameObjectWithTag("Player01").GetComponent<ShakeCamera>();
        txtAk = GameObject.Find("municaoSniper").GetComponent<Text>();      

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
			tempoTiro = Time.time + 1f / fireRate;
			Atirar();
		}


		if (Input.GetButton("PRETO0"))
        {
			StartCoroutine("Recarregar");
		}

	}

	void Atirar()
	{
		if (municao > 0)
		{
			recuo.MexendoCamera(0.06f, 0.2f);
			Instantiate(bala, spawnBala.position, Quaternion.identity);
			municao -= 1;
			Debug.Log("Munição restante " + municao);
		}
	}

	IEnumerator Recarregar()
	{
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1f);
		municao = 1;
	}
}
