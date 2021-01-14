using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira2 : MonoBehaviour
{
    public Camera cameraPlayer;
    public bool playerVivo = true;
    // Start is called before the first frame update
    public float velocidade = 3.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Limitando Mira no tamanho da camera
        var pos = cameraPlayer.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = cameraPlayer.ViewportToWorldPoint(pos);


        //Movimento Mira
        if (playerVivo)
        {
            Vector3 movimento = new Vector3(Input.GetAxis("HORIZONTAL1"), Input.GetAxis("VERTICAL1"), 0.0f);

            transform.position = transform.position + movimento * Time.deltaTime * velocidade;
        }


        LimitarTela();


    }
    public void LimitarTela()
    {
        if (transform.position.x <= 3.795f || transform.position.x >= -20.785f)
        {

            //Criando Limite na posicao Minima -5.6 e na Maxima 5.6
            float xPos = Mathf.Clamp(transform.position.x, -20.785f, 3.795f);

            //Limitando a posicao da nave  com o limite criado no xPos
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        }
        if (transform.position.y <= -16.585f || transform.position.y >= 3.825f)
        {

            //Criando Limite na posicao Minima -5.6 e na Maxima 5.6
            float YPos = Mathf.Clamp(transform.position.y, -16.585f, 3.825f);

            //Limitando a posicao da nave  com o limite criado no xPos
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);

        }
    }
}
