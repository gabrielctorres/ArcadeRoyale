using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public float vida = 1;
    public Animator playerGrafico;
    public Image vidaUI;
    [Header("Armas")]
    float velocidade = 2f;
   public bool andando;
    float timer = 1f;
    bool olhandoDireita, olhandoEsquerda, olhandoCima, olhandoBaixo;
    GameObject Alvo;
    GameObject miraP2;    
    public  bool colidiuPistol,colidiuShotgun,semArma = true,pegouPistol,pegouAK,pegouSniper,pegouShotGun,colidiuGas;

    public bool OlhandoDireita { get => olhandoDireita; set => olhandoDireita = value; }
    public bool OlhandoEsquerda { get => olhandoEsquerda; set => olhandoEsquerda = value; }
    public bool OlhandoCima { get => olhandoCima; set => olhandoCima = value; }
    public bool OlhandoBaixo { get => olhandoBaixo; set => olhandoBaixo = value; }


    // Start is called before the first frame update
    void Start()
    {
       
        miraP2 = GameObject.FindGameObjectWithTag("MiraPlayer02");

    }

    // Update is called once per frame
    void Update()
    {
        vidaUI.fillAmount = vida;

        Alvo = GameObject.FindGameObjectWithTag("MiraPlayer01");
        float distanciaMira = Vector3.Distance(transform.position, Alvo.transform.position);
     
        if(distanciaMira >= 0.5f)
        {
            Animator miraAnima = Alvo.GetComponent<Animator>(); 
            miraAnima.SetBool("miraMedia", true);
            miraAnima.SetBool("miraGrande", false);
            transform.position = transform.position = Vector3.MoveTowards(transform.position, Alvo.transform.position, velocidade / 100);
            andando = true;


        }
        else if (distanciaMira >= 0.7f)
        {
            Animator miraAnima = Alvo.GetComponent<Animator>();
            miraAnima.SetBool("miraMedia", false);
            miraAnima.SetBool("miraGrande", true);
            transform.position = transform.position = Vector3.MoveTowards(transform.position, Alvo.transform.position, velocidade / 100);
            andando = true;

            
        }else if ( distanciaMira <= 0.5f)
        {
            Animator miraAnima = Alvo.GetComponent<Animator>();
            miraAnima.SetBool("miraMedia", false);
            miraAnima.SetBool("miraGrande", false);
            andando = false;
        }  
                
        LimitarTela();
        TomandoDano();

        if( vida <= 0)
        {
            vida = 0;
        }

        MovimentoPlayer();
    }

    public void LimitarTela()
    {
        if (transform.position.x <= 3.775f || transform.position.x >= -20.68f)
        {

            //Criando Limite na posicao Minima -5.6 e na Maxima 5.6
            float xPos = Mathf.Clamp(transform.position.x, -20.68f, 3.786f);

            //Limitando a posicao da nave  com o limite criado no xPos
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        }
        if (transform.position.y <= -16.45f || transform.position.y >= 3.534f)
        {

            //Criando Limite na posicao Minima -5.6 e na Maxima 5.6
            float YPos = Mathf.Clamp(transform.position.y, -16.45f, 3.534f);

            //Limitando a posicao da nave  com o limite criado no xPos
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);

        }
    }


    public void DestroiJogador()
    {
        gameObject.SetActive(false);
    }

    void TomandoDano()
    {
        if (colidiuGas)
        {
			StartCoroutine("DanoGas");
        }
    }

    void MovimentoPlayer()
    {
        //Movimento X
        if (transform.position.x > Alvo.transform.position.x + 0.2 && andando)
        {
            if (pegouAK)
            {
                playerGrafico.SetBool("EsquerdaComAk", true);
                playerGrafico.SetBool("DireitaComAk", false);
                playerGrafico.SetBool("BaixoComAk", false);
                playerGrafico.SetBool("CimaComAk", false);              
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else if (pegouPistol)
            {
                playerGrafico.SetBool("EsquerdaComPistola", true);
                playerGrafico.SetBool("DireitaComPistola", false);
                playerGrafico.SetBool("BaixoComPistola", false);
                playerGrafico.SetBool("CimaComPistola", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else if (pegouSniper)
            {
                playerGrafico.SetBool("EsquerdaComSniper", true);
                playerGrafico.SetBool("DireitaComSniper", false);
                playerGrafico.SetBool("BaixoComSniper", false);
                playerGrafico.SetBool("CimaComSniper", false);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else if (pegouShotGun)
            {
                playerGrafico.SetBool("EsquerdaCom12", true);
                playerGrafico.SetBool("DireitaCom12", false);
                playerGrafico.SetBool("BaixoCom12", false);
                playerGrafico.SetBool("CimaCom12", false);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else
            {
                playerGrafico.SetBool("Esquerda", true);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
        }
        else if (transform.position.x < Alvo.transform.position.x - 0.2 && andando)
        {
            if (pegouAK)
            {
                playerGrafico.SetBool("EsquerdaComAk", false);
                playerGrafico.SetBool("DireitaComAk", true);
                playerGrafico.SetBool("BaixoComAk", false);
                playerGrafico.SetBool("CimaComAk", false);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouPistol)
            {
                playerGrafico.SetBool("EsquerdaComPistola", false);
                playerGrafico.SetBool("DireitaComPistola", true);
                playerGrafico.SetBool("BaixoComPistola", false);
                playerGrafico.SetBool("CimaComPistola", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouSniper)
            {
                playerGrafico.SetBool("EsquerdaComSniper", false);
                playerGrafico.SetBool("DireitaComSniper", true);
                playerGrafico.SetBool("BaixoComSniper", false);
                playerGrafico.SetBool("CimaComSniper", false);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else if (pegouShotGun)
            {
                playerGrafico.SetBool("EsquerdaCom12", false);
                playerGrafico.SetBool("DireitaCom12", true);
                playerGrafico.SetBool("BaixoCom12", false);
                playerGrafico.SetBool("CimaCom12", false);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else
            {
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", true);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
        }


        //Movimento Y
        if (transform.position.y < Alvo.transform.position.y - 0.2 && andando )
        {
            if (pegouAK )
            {
                playerGrafico.SetBool("EsquerdaComAk", false);
                playerGrafico.SetBool("DireitaComAk", false);
                playerGrafico.SetBool("BaixoComAk", false);
                playerGrafico.SetBool("CimaComAk", true);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouPistol)
            {
                playerGrafico.SetBool("EsquerdaComPistola", false);
                playerGrafico.SetBool("DireitaComPistola", false);
                playerGrafico.SetBool("BaixoComPistola", false);
                playerGrafico.SetBool("CimaComPistola", true);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouSniper)
            {
                playerGrafico.SetBool("EsquerdaComSniper", false);
                playerGrafico.SetBool("DireitaComSniper", false);
                playerGrafico.SetBool("BaixoComSniper", false);
                playerGrafico.SetBool("CimaComSniper", true);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else if (pegouShotGun)
            {
                playerGrafico.SetBool("EsquerdaCom12", false);
                playerGrafico.SetBool("DireitaCom12", false);
                playerGrafico.SetBool("BaixoCom12", false);
                playerGrafico.SetBool("CimaCom12", true);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else 
            {
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", true);
                playerGrafico.SetBool("Parado", false);
            }
        }
        else if (transform.position.y > Alvo.transform.position.y + 0.2 && andando)
        {
            if (pegouAK)
            {
                playerGrafico.SetBool("EsquerdaComAk", false);
                playerGrafico.SetBool("DireitaComAk", false);
                playerGrafico.SetBool("BaixoComAk", true);
                playerGrafico.SetBool("CimaComAk", false);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouPistol)
            {
                playerGrafico.SetBool("EsquerdaComPistola", false);
                playerGrafico.SetBool("DireitaComPistola", false);
                playerGrafico.SetBool("BaixoComPistola", true);
                playerGrafico.SetBool("CimaComPistola", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouSniper)
            {
                playerGrafico.SetBool("EsquerdaComSniper", false);
                playerGrafico.SetBool("DireitaComSniper", false);
                playerGrafico.SetBool("BaixoComSniper", true);
                playerGrafico.SetBool("CimaComSniper", false);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else if (pegouShotGun)
            {
                playerGrafico.SetBool("EsquerdaCom12", false);
                playerGrafico.SetBool("DireitaCom12", false);
                playerGrafico.SetBool("BaixoCom12", true);
                playerGrafico.SetBool("CimaCom12", false);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);

            }
            else 
            {
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", true);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("Parado", false);
            }
        }

        if (!andando)
        {
            if (pegouAK)
            {
                playerGrafico.SetBool("EsquerdaComAk",false);
                playerGrafico.SetBool("DireitaComAk",false);
                playerGrafico.SetBool("BaixoComAk",false);
                playerGrafico.SetBool("CimaComAk",false);
                playerGrafico.SetBool("EsquerdaComPistola", false);
                playerGrafico.SetBool("DireitaComPistola", false);
                playerGrafico.SetBool("BaixoComPistola", false);
                playerGrafico.SetBool("CimaComPistola", false);
                playerGrafico.SetBool("EsquerdaComSniper", false);
                playerGrafico.SetBool("DireitaComSniper", false);
                playerGrafico.SetBool("BaixoComSniper", false);
                playerGrafico.SetBool("CimaComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("ParadoComAK", true);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Parado", false);                
            }else if (pegouPistol)
            {
                playerGrafico.SetBool("EsquerdaComAk", false);
                playerGrafico.SetBool("DireitaComAk", false);
                playerGrafico.SetBool("BaixoComAk", false);
                playerGrafico.SetBool("CimaComAk", false);
                playerGrafico.SetBool("EsquerdaComPistola", false);
                playerGrafico.SetBool("DireitaComPistola", false);
                playerGrafico.SetBool("BaixoComPistola", false);
                playerGrafico.SetBool("CimaComPistola", false);
                playerGrafico.SetBool("EsquerdaComSniper", false);
                playerGrafico.SetBool("DireitaComSniper", false);
                playerGrafico.SetBool("BaixoComSniper", false);
                playerGrafico.SetBool("CimaComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("ParadoComPistola", true);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouSniper)
            {
                playerGrafico.SetBool("EsquerdaComAk", false);
                playerGrafico.SetBool("DireitaComAk", false);
                playerGrafico.SetBool("BaixoComAk", false);
                playerGrafico.SetBool("CimaComAk", false);
                playerGrafico.SetBool("EsquerdaComPistola", false);
                playerGrafico.SetBool("DireitaComPistola", false);
                playerGrafico.SetBool("BaixoComPistola", false);
                playerGrafico.SetBool("CimaComPistola", false);
                playerGrafico.SetBool("EsquerdaComSniper", false);
                playerGrafico.SetBool("DireitaComSniper", false);
                playerGrafico.SetBool("BaixoComSniper", false);
                playerGrafico.SetBool("CimaComSniper", false);
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("ParadoComSniper", true);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("Parado", false);
            }
            else if (pegouShotGun)
            {
                playerGrafico.SetBool("EsquerdaCom12", false);
                playerGrafico.SetBool("DireitaCom12", false);
                playerGrafico.SetBool("BaixoCom12", false);
                playerGrafico.SetBool("CimaCom12", false);     
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("ParadoCom12", true);
                playerGrafico.SetBool("Parado", false);

            }
            else 
            {
                playerGrafico.SetBool("Esquerda", false);
                playerGrafico.SetBool("Direita", false);
                playerGrafico.SetBool("Baixo", false);
                playerGrafico.SetBool("Cima", false);
                playerGrafico.SetBool("ParadoComAK", false);
                playerGrafico.SetBool("ParadoComSniper", false);
                playerGrafico.SetBool("ParadoCom12", false);
                playerGrafico.SetBool("ParadoComPistola", false);
                playerGrafico.SetBool("Parado", true);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gas")
        {
           colidiuGas = false;
        }
        if (collision.gameObject.tag == "MiraPlayer02")
        {
            collision.GetComponent<SpriteRenderer>().color = Color.red;
            Mira2 p = collision.GetComponent<Mira2>();
            p.velocidade = 1.5f;
            StopCoroutine("Delay");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gas")
        {
            colidiuGas = true;
            StopCoroutine("DanoGas");
        }
        if(collision.gameObject.tag == "MiraPlayer02")
        {
            collision.GetComponent<SpriteRenderer>().color = Color.white;
            Mira2 p = collision.GetComponent<Mira2>();
            p.velocidade = 3.5f;
            StopCoroutine("Delay");
        }

    }


	IEnumerator DanoGas()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
			vida-=0.002f;
		}
		else
		{
            yield return new WaitForSeconds(3f);
            timer = 1;          

        }
	}
    IEnumerator Delay()
    {
        miraP2.transform.position = transform.position;
        yield return new WaitForSeconds(2);
    }
}
