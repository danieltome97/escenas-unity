using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballcontrol2 : MonoBehaviour
{
    //variables publica
    public float ballforce = 1.0f;

    public float resethigh = 0.6f;

    public Vector3 resetposition;

    public Vector3 finisposition;

    public float finishdistance = 0.25f;


    public GameObject finishtext;


    //variables privadas
    private Vector3 horizontalinput,verticalinput;

    private bool isfinished = false;

     //start
    void Start()
    {
        
    }

    //update
    void Update()
    {
        if (isfinished)
        {
            //el juego ha acabado, esperamos a que se pulse una tecla
            if (Input.anyKeyDown)
            {
             SceneManager.LoadScene(0);
            }
        }
        else
        {
            //controlamos si hay reset
            resetcontrol();

            //movemos la bola
            movementconrol();

            //comprobamos si hemos llegado a la meta
            finischcontrol();
        }
    }
  
    void finischcontrol()
    {
        //comprobar si estamos cerca de la meta
        if( Vector3.Distance(transform.position, finisposition)<finishdistance )
        {
            //hemos llegado a la meta
            //print("he llegado a la meta");
            finishtext.SetActive(true);
            isfinished = true;


        }

    }

    void resetcontrol()
    {
        //comprobar si la altura de la bola es menor que 0.6
        if(transform.position.y < resethigh)
        {
            //nos hemos caido volver a posicion inical
            transform.position = resetposition;

            //reseteamos la velocidad
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);


        }


    }
    void movementconrol()
    {
        //vamos a empujar la bola en la direccion que puse el usuario
        //calculamos el imput horizontal
        horizontalinput = transform.right * Input.GetAxis("Horizontal");
        //calculamos el imput vertical
        verticalinput = transform.forward * Input.GetAxis("Vertical");

        //empujamos la bola con lafuerza "ballforce"
        GetComponent<Rigidbody>().AddForce((horizontalinput) * ballforce);
        GetComponent<Rigidbody>().AddForce((verticalinput) * ballforce);
    }

}
