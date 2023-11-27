using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour
{
    [SerializeField] Transform Right;
    [SerializeField] Transform Left;
    Transform Starts;
    Transform End;
    Transform miTF;
    float Velocity;
    SpriteRenderer miSR;
    // Start is called before the first frame update
    void Start()
    {
        miTF = GetComponent<Transform>();
        miSR = GetComponent<SpriteRenderer>();
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
            Starts = Right;
            End = Left;
            miSR.flipX = true;

       }
       else 
       if(Vector3.Distance(miTF.position, Left.position) < 0.1f)
       {
            Starts = Left;
            End = Right;
            miSR.flipX = false;
       } 
    }
}
