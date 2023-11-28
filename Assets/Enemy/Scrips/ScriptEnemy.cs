using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour
{
    [SerializeField] Transform Right;
    [SerializeField] Transform Left;
    [SerializeField] Transform player;
    Transform Starts;
    Transform End;
    Transform miTF;
    SpriteRenderer miSR;
    Animator miAnim;
    
    
    float Velocity;
    bool Directions;
    // Start is called before the first frame update
    void Start()
    {
        miTF = GetComponent<Transform>();
        miSR = GetComponent<SpriteRenderer>();
        miAnim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        miTF.position = Left.position;
        Starts = Left;
        End = Right;
        Velocity = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {
       miTF.Translate((End.position - Starts.position) * Velocity * Time.deltaTime);
       if(Vector3.Distance(miTF.position, Right.position) < 0.1f)
       {
            Directions = true;
            miSR.flipX = Directions;
       }
       else if(Vector3.Distance(miTF.position, Left.position) < 0.1f)
       {
            Directions = false;
            miSR.flipX = Directions;
       }
       if(Directions)
       {
            Starts = Right;
            End = Left;
       }
       else
       {
            Starts = Left;
            End = Right;
       } 
       if(Vector3.Distance(miTF.position, player.position) < 1f)
       {
            //attack
            Velocity = 0;
            miAnim.SetBool("Attacking", true);
            if(miTF.position.x < player.position.x)
            {
                Directions = false;
            }
            else
            {
                Directions = true;
            }
            miSR.flipX = Directions;
        }
       else
       {
            miAnim.SetBool("Attacking", false);
            Velocity = 0.3f;
            miSR.flipX = Directions;
       }
    }
}
