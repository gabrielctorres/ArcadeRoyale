using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool selecionado = false;

    public Button btnPlay;

    void Update()
    {
        if (Input.GetAxis("VERTICAL0") > 0.0f || Input.GetAxis("VERTICAL0") < 0.0f && selecionado == false)
        {                        
            selecionado = true;
            btnPlay.Select();            
        }
    }


    public void Jogar()
    {
        StartCoroutine("Esperar");
    }
    public void Tutorial()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("tutorial");
    }
    public void Sair()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    IEnumerator Esperar()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene("gambiarra");
       
    }

}
