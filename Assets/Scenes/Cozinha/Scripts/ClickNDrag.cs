using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNDrag : MonoBehaviour
{
    public GameObject selectedObject; // DEIXAR VAZIO
    Vector3 offset;

    public GameObject forma; // O OBJETO ONDE O PLAYER DEVE COLOCAR OS ASSETS

    public Collider2D selectedObjectCollider = null; //DEIXAR VAZIO
    public Collider2D formaCollider = null;// O PROPRIO SCRIPT PREENCHE
    private bool isTouching;
    void Start()
    {
        formaCollider = forma.GetComponent<Collider2D>();
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
                    //Physics2D.IgnoreCollision(selectedObject.GetComponent<Collider2D>(), forma.GetComponent<Collider2D>());  IGNORA A COLISÃO ENTRE DOIS COLLIDERS, NÃO USEI
                }

            }
        }

        if (selectedObjectCollider != null)
        {
            if (selectedObjectCollider.IsTouching(formaCollider)) // VERIFICA SE UM COLLIDER ESTÁ TOCANDO OUTRO
            {
                Debug.Log("is touching");
                isTouching = true;
            }
            else
            {
                isTouching = false;
            }
        }

        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            //Physics2D.IgnoreCollision(selectedObject.GetComponent<Collider2D>(), forma.GetComponent<Collider2D>(),false); DEIXA DE IGNORAR A COLISÃO, NAO USEI

            if (isTouching == false)
            {
                selectedObject.transform.position = selectedObject.GetComponent<PosicaoInicial>().posInicio;
                selectedObject = null;
            }
            else
            {
                forma.GetComponent<Fogao>().VericarCerto(selectedObject.gameObject);
                selectedObject = null;
            }

        }
    }
}
