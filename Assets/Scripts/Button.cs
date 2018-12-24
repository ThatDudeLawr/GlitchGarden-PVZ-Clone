using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject prefabInstance;
    public static GameObject selectedDefender;
    private Color startcolor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter()
	{
		Debug.Log(name + "highlighted.");

		startcolor=GetComponent<SpriteRenderer>().color;
		GetComponent<SpriteRenderer>().color=Color.black;
        selectedDefender = prefabInstance;
	}

	void OnMouseExit()
 {
     GetComponent<SpriteRenderer>().color = startcolor;
 }

}
