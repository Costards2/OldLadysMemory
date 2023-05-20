using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atira : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {

        GameObject arma = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        
    }
}
