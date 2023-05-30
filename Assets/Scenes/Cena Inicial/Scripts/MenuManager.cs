using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelMenuSecundario;
    [SerializeField] private GameObject receitas;
    [SerializeField] private GameObject flores;

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Receitas()
    {
        SceneManager.LoadScene("Cozinha");
    }

    public void PreCafe()
    {
        SceneManager.LoadScene("PréCafe");
    }

    public void Flores()
    {
        SceneManager.LoadScene("Flores");
    }

    public void Jogar()
    {
        painelMenuInicial.SetActive(false);
        painelMenuSecundario.SetActive(true);
    }

    public void Opcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void VoltarOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("Sair");
        Application.Quit();
    }

}