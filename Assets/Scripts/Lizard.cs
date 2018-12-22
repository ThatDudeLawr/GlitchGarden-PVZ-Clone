using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attackers))]
public class Lizard : MonoBehaviour {

	private Attackers attacker;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
		attacker = GetComponent<Attackers>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject obj = collider.gameObject;
		if(!obj.GetComponent<Defenders>())
		{
			return;
		}
		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);
		attacker.StrikeCurrentTarget(15f);
		if(obj.GetComponent<Health>().HP < 0)
		{
			anim.SetBool("isAttacking", false);
		}
	}
}
