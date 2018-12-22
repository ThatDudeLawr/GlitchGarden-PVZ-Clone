using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void DealDamage(float damage){
		HP-=damage;
		if(HP<0)
		{
			//Optionally used for Death animation inside the animator
			DestroyObject();
		}
	}

	void DestroyObject(){
		Destroy(gameObject);
	}
}
