using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGas : MonoBehaviour
{

    public GameObject[] alvos;

    int index;
    Vector3 alvoAtual;
    public GameObject gas;   


    public float timeMovimento = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, alvos.Length);
        alvoAtual = alvos[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine("IniciandoSafe");

    }

    void AumentarGas()
    {

        gas.transform.position = alvoAtual;


		if (gas.transform.localScale.x >= -0 && gas.transform.localScale.y >= -0) 
		{
			gas.transform.localScale -= new Vector3(0.001f, 0.001f, 0f);
		}else
		{
			gas.transform.localScale -= new Vector3(0f, 0f, 0f);

		}


    }


    IEnumerator EsperarSafe()
    {
        if (timeMovimento > 0)
        {
            timeMovimento -= Time.deltaTime;
            AumentarGas();
        }
        else
        {
            yield return new WaitForSeconds(4.0f);
            timeMovimento = 0.8f;

        }
    }


   IEnumerator IniciandoSafe()
    {
        yield return new WaitForSeconds(4f);
        StartCoroutine("EsperarSafe");
    }
}
