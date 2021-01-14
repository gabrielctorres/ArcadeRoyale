using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControladorVitoria : MonoBehaviour
{
    Player player01;
    Player2 player02;
    Camera camera1;
    Camera camera2;
    Mira miraPlayer01;
    Mira2 miraPlayer02;
    public GameObject canvas;
    public GameObject txtAviso;
    public Text txtganhador;
    public Text txtTempo;
    string ganhador;
    int tempo;
    bool Emjogo = true;    
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);        

        player01 = GameObject.FindGameObjectWithTag("Player01").GetComponent<Player>();
        miraPlayer01 = GameObject.FindGameObjectWithTag("MiraPlayer01").GetComponent<Mira>();
        camera1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        player02 = GameObject.FindGameObjectWithTag("Player02").GetComponent<Player2>();
        miraPlayer02 = GameObject.FindGameObjectWithTag("MiraPlayer02").GetComponent<Mira2>();
        camera2 = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Emjogo)
        {
            tempo = (int)Time.time;
            txtTempo.text = tempo.ToString() + " Segundos";           
        }
        txtganhador.text = ganhador;
        if (player01.vida <= 0)
        {           
            ganhador = "Jogador 2";
            player01.DestroiJogador();            
            Destroy(miraPlayer01);
            camera2.rect = new Rect(0, 0.0f, 1.0f - 0 * 2.0f, 1.0f);
            miraPlayer02.playerVivo = false;           
            canvas.SetActive(true);
            StartCoroutine("PiscarTexto");
            Emjogo = false;
        }
        else if(player02.vida <= 0)
        {            
            ganhador = "Jogador 1";
            player02.DestroiJogador();
            Destroy(miraPlayer02);
            camera1.rect = new Rect(0, 0.0f, 1.0f - 0 * 2.0f, 1.0f);
            miraPlayer01.playerVivo = false;           
            canvas.SetActive(true);
            StartCoroutine("PiscarTexto");
            Emjogo = false;
        }


        if (canvas.activeInHierarchy)
        {
            if (Input.GetButton("MENU"))
            {
				Application.LoadLevel("menu");
            }
        }
    }

    void Piscando()
    {
        StartCoroutine("PiscarTexto");
    }

    IEnumerator PiscarTexto()
    {
        txtAviso.SetActive(false);
        yield return new WaitForSeconds(1f);
        txtAviso.SetActive(true);
    }
}
