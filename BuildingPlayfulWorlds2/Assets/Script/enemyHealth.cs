using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;

    float currentHealth;
    public float aliveTime;
    public GameObject deathFX;
    Rigidbody2D enemyRB;

    // Use this for initialization
    void Start () {
        enemyRB = GetComponent<Rigidbody2D>();
        currentHealth = enemyMaxHealth;

	}
	
	// Update is called once per frame
	void Update () {
       

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("swordAttack")){

        }
    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) makeDead();
    }
    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject, aliveTime);
    }

}
