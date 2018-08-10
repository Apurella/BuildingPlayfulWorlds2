using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;

    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="Player" && nextDamage < Time.time)
        {
            playerHealth myPH = other.gameObject.GetComponent<playerHealth>();
            myPH.addDamage(damage);
            nextDamage = Time.time + damageRate;
        }
    }
}
