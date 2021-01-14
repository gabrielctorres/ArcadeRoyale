using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    public float velocidade;
    public float tempoVida;
    public float dano;
    public GameObject sangue;
    public GameObject particula;
    Rigidbody2D rb2d;
    GameObject Alvo;
    Vector2 direçaoMovimento;
    Player player01;
    // Start is called before the first frame update
    void Start()
    {
        player01 = GameObject.FindGameObjectWithTag("Player01").GetComponent<Player>();
        Alvo = GameObject.FindGameObjectWithTag("MiraPlayer02");
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
        if (collision.gameObject.tag == "Player01")
        {
            Vector2 playerPos = new Vector2(collision.transform.position.x, collision.transform.position.y + (-0.2f));
            player01.vida -= dano;
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
