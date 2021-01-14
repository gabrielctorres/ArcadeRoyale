using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTutorial : MonoBehaviour
{
    private bool selecionado = false;

    public Button btnAvancar;

    public GameObject canvas01, canvas02, canvas03;

    int contagem = 1;

    void Update()
    {
        if (Input.GetAxis("HORIZONTAL0") > 0.0f || Input.GetAxis("HORIZONTAL0") < 0.0f && selecionado == false)
        {
            selecionado = true;
            btnAvancar.Select();
        }


        if (contagem == 1)
        {
            canvas01.SetActive(true);
            canvas02.SetActive(false);
            canvas03.SetActive(false);
        }
        else if (contagem == 2) 
        {
            canvas01.SetActive(false);
            canvas02.SetActive(true);
            canvas03.SetActive(false);
        }
        else if (contagem == 3)
        {
            canvas01.SetActive(false);
            canvas02.SetActive(false);
            canvas03.SetActive(true);
        }
        else if (contagem <=0)
        {
            SceneManager.LoadScene("menu");
        }
        else if (contagem >= 3)
        {
            SceneManager.LoadScene("menu");
        }
        else
        {
            SceneManager.LoadScene("menu");
        }


        

    }


    public void Avancar()
    {
        GetComponent<AudioSource>().Play();
        contagem++;
    }
    public void Voltar()
    {
        GetComponent<AudioSource>().Play();
        contagem--;
    }
}
