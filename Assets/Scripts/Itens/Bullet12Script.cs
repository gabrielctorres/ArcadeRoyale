using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet12Script : MonoBehaviour
{
    float velocidade;
    public float tempoVida;
    public float dano;
    public GameObject sangue;
    public GameObject particula;
    Rigidbody2D rb2d;
    GameObject Alvo;
    Vector2 direçaoMovimento;
    Player2 player02;
    // Start is called before the first frame update
    void Start()
    {
        player02 = GameObject.FindGameObjectWithTag("Player02").GetComponent<Player2>();
        velocidade = Random.Range(1.5f, 2f);
        Alvo = GameObject.FindGameObjectWithTag("MiraPlayer01");
        Invoke("DestroiBala", tempoVida);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().Play();
        direçaoMovimento = (Alvo.transform.position - transform.position).normalized * velocidade;
        rb2d.velocity = new Vector2(direçaoMovimento.x, direçaoMovimento.y);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }
    void DestroiBala()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player02")
        {
            Vector2 playerPos = new Vector2(collision.transform.position.x + (0.3f), collision.transform.position.y);
            Quaternion rotation = Quaternion.Euler(0, 30, 0);
            player02.vida -= dano;
            Instantiate(sangue, transform.position, rotation);
            DestroiBala();
        }
        if (collision.gameObject.tag == "Arvore")
        {
            DestroiBala();
        }
        if (collision.gameObject.tag == "TileMap")
        {
            DestroiBala();
        }
    }


}
