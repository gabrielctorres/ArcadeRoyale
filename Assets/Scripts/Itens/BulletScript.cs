using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float velocidade;
    public float tempoVida;
    public GameObject sangue;
    public GameObject particula;
    Rigidbody2D rb2d;
    GameObject Alvo;
    Player2 player02;
    Vector2 direçaoMovimento;
    public float dano;
    // Start is called before the first frame update
    void Start()
    {
        player02 = GameObject.FindGameObjectWithTag("Player02").GetComponent<Player2>();
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
        if (collision.gameObject.tag == "Player02")
        {
            Vector2 playerPos = new Vector2(collision.transform.position.x, collision.transform.position.y + (-0.2f));            
            player02.vida -= dano;
            Instantiate(sangue, transform.position, Quaternion.identity);
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
