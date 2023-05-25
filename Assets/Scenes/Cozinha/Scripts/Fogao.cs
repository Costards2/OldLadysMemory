using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogao : MonoBehaviour
{

    //-------------COLOCAR ESTE SCRIPT NO OBJETO ONDE O PLAYER DEVE COLOCAR OS OBJETOS-----------------

    public GameObject[] objeto; // PREENCHER A LISTA NO UNITY COM OS OJETOS NA ORDEM QUE O PLAYER DEVE COLOCAR
    private int nCerto; // INDICE DOS OBJETOS CERTOS, O PROGRAMA Jﾁ COLOCA
    public GameObject mainCamera; // COLOCAR O OBJETO ONDE ESTA O SCRIPT CLICKNDRAG
    public int nMemoria;
    public GameObject mãe;
    public GameObject ingredientes;
    public GameObject musica;
    public GameObject mudança; 

    // Start is called before the first frame update
    void Start()
    {
        nCerto = 0;
        nMemoria = 0; 

    }

    public void VericarCerto(GameObject collision)
    {
        if (nCerto < 6) // SUBSTITUIR O NUMERO PELA QUANTIDADE DE OBJETOS CERTOS
        {

            if (collision.gameObject == objeto[nCerto])
            {
                Debug.Log("objeto certo " + nCerto);
                collision.transform.position = transform.position;
                collision.GetComponent<Collider2D>().enabled = false; //DESATIVA O COLLIDER, O PLAYER NﾃO PODE RETIRAR O OBJETO DO LUGAR CERTO
                collision.GetComponent<SpriteRenderer>().enabled = false;
                nCerto++;
                nMemoria++;

                if (nMemoria == 6)
                {
                   mãe.SetActive(true);
                   ingredientes.SetActive(false);
                   musica.SetActive(false);
                   mudança.SetActive(true);
                }

            }
            else
            {
                collision.transform.position = collision.GetComponent<PosicaoInicial>().posInicio;
                Debug.Log("objeto errado");
            }

            if (nMemoria == 6)
            {
                mãe.SetActive(true);
                ingredientes.SetActive(false);
                musica.SetActive(false);
                mudança.SetActive(true);
            }
        }
    }

}