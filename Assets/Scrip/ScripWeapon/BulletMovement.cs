using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Transform Spaw;
    [SerializeField] float velocidad;
    [SerializeField] private List<GameObject> Bullet = new List<GameObject>();

    private int currentBulletIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(Bullet[currentBulletIndex], Spaw.position, Spaw.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = Spaw.forward * velocidad;
        }

        if (Input.GetKeyDown(KeyCode.E)) currentBulletIndex = (currentBulletIndex + 1) % Bullet.Count;
        if (Input.GetKeyDown(KeyCode.Q)) currentBulletIndex = (currentBulletIndex - 1) % Bullet.Count;

    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.GetDamage();
            Destroy(gameObject);
        }
    }
}



