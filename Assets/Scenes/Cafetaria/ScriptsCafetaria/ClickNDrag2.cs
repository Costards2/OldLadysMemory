using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNDrag2 : MonoBehaviour
{


    public GameObject selectedObject; // DEIXAR VAZIO
    Vector3 offset;

    [SerializeField] public GameObject[] forma; // O OBJETO ONDE O PLAYER DEVE COLOCAR OS ASSETS
    public int formaIndice;
    [SerializeField] public GameObject[] objetos;
    public int objetoIndice;

    public int n2Certo;
    public int m2Memorias;

    public Collider2D selectedObjectCollider = null; //DEIXAR VAZIO
    private Collider2D[] formaCollider = new Collider2D[6];// O PROPRIO SCRIPT PREENCHE
    public bool isTouching;

    public GameObject pessoas;
    public GameObject veia;
    public GameObject memoria;
    public GameObject proximo;
    public GameObject mudança;
    public AudioClip certo; 


    void Start()
    {
        m2Memorias = 0; 
        n2Certo = 0;
        
        for (int i = 0; i < 6; i++)
        {
            formaCollider[i] = forma[i].GetComponent<Collider2D>();
        }
        isTouching = false;
    }

    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                if (targetObject.tag == "1") //COLOCAR A TAG DOS OBJETOS QUE PODEM SER ARRASTADOS
                {
                    selectedObject = targetObject.gameObject;
                    offset = selectedObject.transform.position - mousePosition;
                    selectedObjectCollider = selectedObject.GetComponent<Collider2D>();
                }

            }
        }

        if (selectedObjectCollider != null)
        {
            for (int i = 0; i < 6; i++)
            {
                if (selectedObjectCollider.IsTouching(formaCollider[i]))
                {
                    isTouching = true;
                    formaIndice = i;
                    break;
                }
                else
                {
                    isTouching = false;
                }
            }
        }

        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
            for (int i = 0; i < 6; i++)
            {
                if (selectedObject == objetos[i])
                {
                    objetoIndice = i;
                }
            }



            if (Input.GetMouseButtonUp(0) && selectedObject)
            {
                if (isTouching == false)
                {
                    //Debug.Log("no touching");
                    selectedObject.transform.position = selectedObject.GetComponent<PosicaoInicial2>().posInicio;
                    selectedObject = null;
                    selectedObjectCollider = null;
                }
                else
                {

                    if (objetoIndice == formaIndice)
                    {
                        //Debug.Log("objeto certo " + n2Certo);
                        selectedObject.transform.position = forma[formaIndice].transform.position;
                        selectedObject.GetComponent<Collider2D>().enabled = false; //DESATIVA O COLLIDER, O PLAYER NﾃO PODE RETIRAR O OBJETO DO LUGAR CERTO
                        n2Certo++;
                        
                        selectedObject = null;
                        selectedObjectCollider = null;
                        m2Memorias++;
                        if (m2Memorias == 6)
                        {
                            veia.SetActive(false);
                            pessoas.SetActive(false);
                            memoria.SetActive(true);
                            mudança.SetActive(true);
                            proximo.SetActive(true);
                        }


                    }


                    else
                    {
                        selectedObject.transform.position = selectedObject.GetComponent<PosicaoInicial2>().posInicio;
                        //Debug.Log("lugar errado");
                        selectedObject = null;
                        selectedObjectCollider = null;
                    }
                }

            }
        }

    }
}
