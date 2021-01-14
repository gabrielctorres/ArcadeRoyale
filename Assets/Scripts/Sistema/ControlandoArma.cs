using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlandoArma : MonoBehaviour
{
   public int tipoArma; //1 - Pistola //2 - AK e assim vai ...
    bool pistolaSelecionada = false;
    bool shootGunSelecionada = false;
    bool ak47Selecionada = false;
	bool sniperSelecionada = false;
    bool pistolaSelecionada2 = false;
    bool shootGunSelecionada2 = false;
    bool ak47Selecionada2 = false;
    bool sniperSelecionada2 = false;
    public GameObject pistola,pistola2;
    public GameObject shotGun,shotGun2;
    public GameObject ak47,ak472;
	public GameObject sniper,sniper2;
    public GameObject textoAk,texto12,textoSniper,textoPistola,uiArma;
    public GameObject textoAk2, texto122, textoSniper2, textoPistola2, uiArma2;
    public Transform armaOrigem,armaOrigem2;
    Camera cm;
    Camera cm2;
    Player playerScript;
    Player2 playerScript2;
    Mira miraP01;
    Mira2 miraP02;
    GameObject player;
    GameObject player2;
    //  public int TipoArma;// { get => tipoArma; set => tipoArma = value; }


    GameObject PistolaInstanciada, ShootGunInstanciada,ak47Instanciada,sniperInstanciada;
    GameObject PistolaInstanciada2, ShootGunInstanciada2, ak47Instanciada2, sniperInstanciada2;

    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cm2 = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Camera>();
        miraP01 = GameObject.FindGameObjectWithTag("MiraPlayer01").GetComponent<Mira>();
        miraP02 = GameObject.FindGameObjectWithTag("MiraPlayer02").GetComponent<Mira2>();
        player = GameObject.FindGameObjectWithTag("Player01");
        player2 = GameObject.FindGameObjectWithTag("Player02");
        playerScript = GameObject.FindGameObjectWithTag("Player01").GetComponent<Player>();
        playerScript2 = GameObject.FindGameObjectWithTag("Player02").GetComponent<Player2>();


    }

    // Update is called once per frame
    void Update()
    {
        CriandoArmas();
        CriandoArmas2();
    }



    void CriandoArmas()
    {        
        if (tipoArma == 1 && !pistolaSelecionada)
        {
            miraP01.velocidade = 4.0f;
            Destroy(ShootGunInstanciada);
            Destroy(ak47Instanciada);
            Destroy(sniperInstanciada);
            pistolaSelecionada = true;
            shootGunSelecionada = false;
            sniperSelecionada = false;
            ak47Selecionada = false;
            PistolaInstanciada = Instantiate(pistola, armaOrigem.position, Quaternion.identity);
            PistolaInstanciada.transform.parent = player.transform;
            textoAk.SetActive(false);
            texto12.SetActive(false);
            textoSniper.SetActive(false);
            textoPistola.SetActive(true);
            uiArma.SetActive(true);
            playerScript.pegouPistol = true;
            playerScript.pegouAK = false;
            playerScript.pegouSniper = false;
			playerScript.semArma = false;
            playerScript.pegouShotGun = false;
            cm.orthographicSize = 1f;
        }
        else if (tipoArma == 2 && !shootGunSelecionada)
        {
            miraP01.velocidade = 3.0f;
            Destroy(PistolaInstanciada);
            Destroy(sniperInstanciada);
            Destroy(ak47Instanciada);
            pistolaSelecionada = false;
            ak47Selecionada = false;
            sniperSelecionada = false;
            shootGunSelecionada = true;
            ShootGunInstanciada = Instantiate(shotGun, armaOrigem.position, Quaternion.identity);
            ShootGunInstanciada.transform.parent = player.transform;
            playerScript.pegouPistol = false;
            playerScript.pegouAK = false;
            playerScript.pegouSniper = false;
            playerScript.pegouShotGun = true;
            playerScript.semArma = false;
            textoAk.SetActive(false);
            texto12.SetActive(true);
            textoSniper.SetActive(false);
            textoPistola.SetActive(false);
            uiArma.SetActive(true);
            cm.orthographicSize = 1f;
        }
        else if (tipoArma == 3 && !ak47Selecionada)
        {
            miraP01.velocidade = 3.0f;
            Destroy(PistolaInstanciada);
            Destroy(sniperInstanciada);
            Destroy(ShootGunInstanciada);
            pistolaSelecionada = false;
            shootGunSelecionada = false;
            sniperSelecionada = false;
            ak47Selecionada = true;
            ak47Instanciada = Instantiate(ak47, armaOrigem.position, Quaternion.identity);
            ak47Instanciada.transform.parent = player.transform;
            playerScript.pegouPistol = false;
            playerScript.pegouSniper = false;
			playerScript.semArma = false;
            playerScript.pegouShotGun = false;
            playerScript.pegouAK = true;
            textoAk.SetActive(true);
            texto12.SetActive(false);
            textoSniper.SetActive(false);
            textoPistola.SetActive(false);
            uiArma.SetActive(true);
            cm.orthographicSize = 1f;
        }
        else if (tipoArma == 4 && !sniperSelecionada)
        {
            miraP01.velocidade = 2.5f;
            Destroy(PistolaInstanciada);
            Destroy(ShootGunInstanciada);
            Destroy(ak47Instanciada);
            pistolaSelecionada = false;
            shootGunSelecionada = false;
            ak47Selecionada = false;
            sniperSelecionada = true;
            sniperInstanciada = Instantiate(sniper, armaOrigem.position, Quaternion.identity);
            sniperInstanciada.transform.parent = player.transform;
            playerScript.pegouPistol = false;
            playerScript.pegouAK = false;
			playerScript.semArma = false;
            playerScript.pegouShotGun = false;
            playerScript.pegouSniper = true;    
            textoAk.SetActive(false);
            texto12.SetActive(false);
            textoSniper.SetActive(true);
            textoPistola.SetActive(false);
            uiArma.SetActive(true);
            cm.orthographicSize = 2f;
        }
        else if (tipoArma == 0 && (sniperSelecionada || pistolaSelecionada || ak47Selecionada || shootGunSelecionada) )
        {
            miraP01.velocidade = 3.5f;
            Destroy(PistolaInstanciada);
            Destroy(ShootGunInstanciada);
            Destroy(ak47Instanciada);
            Destroy(sniperInstanciada);
            pistolaSelecionada = false;
            shootGunSelecionada = false;
            sniperSelecionada = false;
            ak47Selecionada = false;
            playerScript.pegouPistol = false;
            playerScript.pegouAK = false;
			playerScript.semArma = true;
            playerScript.pegouShotGun = false;
            playerScript.pegouSniper = false;
            textoAk.SetActive(false);
            texto12.SetActive(false);
            textoSniper.SetActive(false);
            textoPistola.SetActive(false);
            uiArma.SetActive(false);
            cm.orthographicSize = 1f;
        }
    }
    void CriandoArmas2()
    {
        if (tipoArma == 5 && !pistolaSelecionada2)
        {
            miraP01.velocidade = 4.0f;
            Destroy(ShootGunInstanciada2);
            Destroy(ak47Instanciada2);
            Destroy(sniperInstanciada2);
            pistolaSelecionada2 = true;
            shootGunSelecionada2 = false;
            sniperSelecionada2 = false;
            ak47Selecionada2 = false;
            PistolaInstanciada2 = Instantiate(pistola2, armaOrigem2.position, Quaternion.identity);
            PistolaInstanciada2.transform.parent = player2.transform;
            textoAk2.SetActive(false);
            texto122.SetActive(false);
            textoSniper2.SetActive(false);
            textoPistola2.SetActive(true);
            uiArma2.SetActive(true);
            playerScript2.pegouPistol = true;
            playerScript2.pegouAK = false;
            playerScript2.pegouSniper = false;
            playerScript2.semArma = false;
            playerScript2.pegouShotGun = false;
            cm2.orthographicSize = 1f;
        }
        else if (tipoArma == 6 && !shootGunSelecionada2)
        {
            miraP01.velocidade = 3.0f;
            Destroy(PistolaInstanciada2);
            Destroy(sniperInstanciada2);
            Destroy(ak47Instanciada2);
            pistolaSelecionada2 = false;
            ak47Selecionada2 = false;
            sniperSelecionada2 = false;
            shootGunSelecionada2 = true;
            ShootGunInstanciada2 = Instantiate(shotGun2, armaOrigem2.position, Quaternion.identity);
            ShootGunInstanciada2.transform.parent = player2.transform;
            playerScript2.pegouPistol = false;
            playerScript2.pegouAK = false;
            playerScript2.pegouSniper = false;
            playerScript2.pegouShotGun = true;
            playerScript2.semArma = false;
            textoAk2.SetActive(false);
            texto122.SetActive(true);
            textoSniper2.SetActive(false);
            textoPistola2.SetActive(false);
            uiArma2.SetActive(true);
            cm2.orthographicSize = 1f;
        }
        else if (tipoArma == 7 && !ak47Selecionada2)
        {
            miraP01.velocidade = 3.0f;
            Destroy(PistolaInstanciada2);
            Destroy(sniperInstanciada2);
            Destroy(ShootGunInstanciada2);
            pistolaSelecionada2 = false;
            shootGunSelecionada2 = false;
            sniperSelecionada2 = false;
            ak47Selecionada2 = true;
            ak47Instanciada2 = Instantiate(ak472, armaOrigem2.position, Quaternion.identity);
            ak47Instanciada2.transform.parent = player2.transform;
            playerScript2.pegouPistol = false;
            playerScript2.pegouSniper = false;
            playerScript2.semArma = false;
            playerScript2.pegouShotGun = false;
            playerScript2.pegouAK = true;
            textoAk2.SetActive(true);
            texto122.SetActive(false);
            textoSniper2.SetActive(false);
            textoPistola2.SetActive(false);
            uiArma2.SetActive(true);
            cm2.orthographicSize = 1f;
        }
        else if (tipoArma == 8 && !sniperSelecionada2)
        {
            miraP01.velocidade = 2.5f;
            Destroy(PistolaInstanciada2);
            Destroy(ShootGunInstanciada2);
            Destroy(ak47Instanciada2);
            pistolaSelecionada2 = false;
            shootGunSelecionada2 = false;
            ak47Selecionada2 = false;
            sniperSelecionada2 = true;
            sniperInstanciada2 = Instantiate(sniper2, armaOrigem2.position, Quaternion.identity);
            sniperInstanciada2.transform.parent = player2.transform;
            playerScript2.pegouPistol = false;
            playerScript2.pegouAK = false;
            playerScript2.semArma = false;
            playerScript2.pegouShotGun = false;
            playerScript2.pegouSniper = true;
            textoAk2.SetActive(false);
            texto122.SetActive(false);
            textoSniper2.SetActive(true);
            textoPistola2.SetActive(false);
            uiArma2.SetActive(true);
            cm2.orthographicSize = 2f;
        }
        else if (tipoArma == 9 && (sniperSelecionada2 || pistolaSelecionada2 || ak47Selecionada2 || shootGunSelecionada2))
        {
            miraP01.velocidade = 3.5f;
            Destroy(PistolaInstanciada2);
            Destroy(ShootGunInstanciada2);
            Destroy(ak47Instanciada2);
            Destroy(sniperInstanciada2);
            pistolaSelecionada2 = false;
            shootGunSelecionada2 = false;
            sniperSelecionada2 = false;
            ak47Selecionada2 = false;
            playerScript2.pegouPistol = false;
            playerScript2.pegouAK = false;
            playerScript2.semArma = true;
            playerScript2.pegouShotGun = false;
            playerScript2.pegouSniper = false;
            textoAk2.SetActive(false);
            texto122.SetActive(false);
            textoSniper2.SetActive(false);
            textoPistola2.SetActive(false);
            uiArma2.SetActive(false);
            cm2.orthographicSize = 1f;
        }
    }
}
