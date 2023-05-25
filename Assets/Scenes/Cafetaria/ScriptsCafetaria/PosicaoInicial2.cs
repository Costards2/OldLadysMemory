using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicaoInicial2 : MonoBehaviour
{

    //------------COLOCAR EM CADA OBJETO QUE O PLAYER PODE ARRASTAR--------------

    public Vector3 posInicio = new Vector3();

    void Start()
    {
        posInicio = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

}
