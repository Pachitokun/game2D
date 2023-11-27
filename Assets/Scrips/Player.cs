using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movimiento;
    [SerializeField]float InteractX;
    [SerializeField] bool enSuelo;
    float FuerzaSalto;
    float velocidad;
    
    
    Transform miTF;
    Animator miAnim;
    private Rigidbody2D miRB;
    SpriteRenderer miSR;
    
    void Start()
    {
        velocidad = 2f;
        FuerzaSalto = 200f;
        miTF = gameObject.transform;
        movimiento = miTF.position.x;
        miSR = gameObject.GetComponent<SpriteRenderer>();
        miAnim = gameObject.GetComponent<Animator>();
        miRB = GetComponent<Rigidbody2D>();
        enSuelo = true;

    }

    //// Update is called once per frame
    void Update()
    {
        InteractX = Input.GetAxisRaw("Horizontal");
        movimiento += velocidad * Time.deltaTime * InteractX;
        miTF.transform.position = new Vector2(movimiento, miTF.position.y);
        
        if(InteractX != 0)
        {
            miAnim.SetBool("Caminando", true);
            if (InteractX < 0)
            {
                miSR.flipX = true;
            }
            else 
            {
                miSR.flipX = false;
            }
        }
        else
        {
            miAnim.SetBool("Caminando", false);
        }

        if (Input.GetKeyDown("space") && enSuelo == true)
        {
            miRB.AddForce(Vector2.up * 500);
            enSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Ground")
        {
            enSuelo = true;
           // miAnim.SetBool("Saltando", false);
            
        }
        /*else if(collision.gameObject.tag == "Ground")
        {
            enSuelo = false;
            //miAnim.SetBool("Saltando", true);
            
        }*/
    }
}
