using UnityEngine;
using System.Collections;

public class MoveFundo : MonoBehaviour {

  public float velocidade; 

  void Update(){

        MovimentarCenario();

  }

  private void MovimentarCenario(){
      
    Vector2 deslocamento = new Vector2(Time.time * velocidade, 0);
    GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
 
  }


}