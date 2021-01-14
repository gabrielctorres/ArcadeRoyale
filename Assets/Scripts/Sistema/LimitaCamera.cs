using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitaCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitarTela();
    }

    public void LimitarTela()
    {
        if (transform.position.x <= 3.644f || transform.position.x >= -20.5f)
        {

            //Criando Limite na posicao Minima -5.6 e na Maxima 5.6
            float xPos = Mathf.Clamp(transform.position.x, -20.5f, 3.644f);

            //Limitando a posicao da nave  com o limite criado no xPos
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        }
        if (transform.position.y <= 3.732f || transform.position.y >= -16.44f)
        {

            //Criando Limite na posicao Minima -5.6 e na Maxima 5.6
            float YPos = Mathf.Clamp(transform.position.y, -16.44f, 3.732f);

            //Limitando a posicao da nave  com o limite criado no xPos
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);

        }
    }
}
