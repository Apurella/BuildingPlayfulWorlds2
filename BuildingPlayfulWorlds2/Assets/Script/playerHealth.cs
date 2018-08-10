using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject deathFX;
    public GameObject respawnPoint;
    public float respawnDelay;

    float currentHealth;

    //playerController controlMovement;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;
     //   controlMovement = GetComponent<playerController>();

	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag ("droptodeath")){
            SceneManager.LoadScene("game");
        }
    }
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    public void makeDead()
    {

        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene("game");
    }
}
