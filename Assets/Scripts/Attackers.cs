using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attackers : MonoBehaviour {

	// Use this for initialization
	[Range(-1f,2f)]
	public float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget)
		{
			anim.SetBool("isAttacking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	public void setSpeed(float speed)
    {
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage)
    {
		if(currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			if(health)
			{
			health.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject obj)
    {
		currentTarget = obj;
	}
}
