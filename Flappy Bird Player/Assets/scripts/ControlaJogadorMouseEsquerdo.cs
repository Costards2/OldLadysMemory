using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogadorMouseEsquerdo : MonoBehaviour {

    public float moveSpeed = 15f;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int maxHealth = 5;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    void Shoot()
    {
        shootingPoint.rotation = gameObject.transform.rotation;
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
