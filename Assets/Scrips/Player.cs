using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
   //bool
    [SerializeField] bool enSuelo;
    private bool isGrounded;
    bool facingRight;
   //floats Privados
    [SerializeField] private float movimiento;
    private float moveInput;
   

    //Floats publicos
     public float groundDist;
    public float FuerzaSalto;
    public float runSpeed;
    public float move;
    
    
    
    //floats normales
    float velocidad;
    [SerializeField]float InteractX;
    [SerializeField]float InteractY;
    
    public LayerMask terrainLayer;
    
    
    public Transform miTF;
    public float checkRadius;
    public LayerMask whatIsGround;
    Animator miAnim;
    private Rigidbody miRB;
    SpriteRenderer miSR;
    
    void Start()
    {
        velocidad = 4f;
        FuerzaSalto = 200f;
        miTF = gameObject.transform;
        movimiento = miTF.position.x;
        miSR = gameObject.GetComponent<SpriteRenderer>();
        miAnim = gameObject.GetComponent<Animator>();
        miRB = GetComponent<Rigidbody>();
        enSuelo = true;
        
    }

   
    void FixedUpdate()
    {
        move = Input.GetAxisRaw("Sprint");
        miAnim.SetFloat("Run", Mathf.Abs(move));

        miRB.velocity = new Vector3(move * runSpeed, miRB.velocity.y, 0);
        facingRight = true;

        if(move > 0 && !facingRight) Flip();
        else if(move < 0 && facingRight) Flip();
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z =- 100;
        transform.localScale = theScale;
    }
    //// Update is called once per frame
    void Update()
    {
        InteractY = Input.GetAxisRaw("Vertical");
        InteractX = Input.GetAxisRaw("Horizontal");
        movimiento += velocidad * Time.deltaTime * InteractX;
        miTF.transform.position = new Vector3(movimiento, miTF.position.y);
        
        Vector3 moveDir = new Vector3(InteractX, 0, InteractY);
        miRB.velocity = moveDir * velocidad;
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
            miAnim.SetBool("Saltando", true);
            miRB.AddForce(Vector2.up * 1000);
            enSuelo = false;
        }
        else
        {
            miAnim.SetBool("Saltando", false);
            enSuelo = true;
        }
    //obtener la velocidad en Y del animador del jugador
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        miAnim.SetBool("Saltando", !enSuelo);
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Ground")
        {
            enSuelo = true;
           // miAnim.SetBool("Saltando", false);
            
        }
        else if(other.gameObject.tag == "Ground")
        {
            enSuelo = false;
            //miAnim.SetBool("Saltando", true);
            
        }
    }
}
