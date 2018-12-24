using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    public GameObject defenderParent;

	// Use this for initialization
	void Start () {
        defenderParent = GameObject.Find("Defenders");
        if(!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
	}
	


    private void OnMouseDown()
    {
        Vector2 rawPosition = MousePositionToWorldCoordinates();
        Vector2 roundPosition = SnapToGrid(rawPosition);

        GameObject defender =  Instantiate(Button.selectedDefender, roundPosition, Quaternion.identity);
        defender.transform.parent = defenderParent.transform;
    }

    // Rounded World coordinates

    Vector2 SnapToGrid(Vector2 rawCoordinates)
    {
        Vector2 roundCoordinates;
        roundCoordinates.x = Mathf.RoundToInt( rawCoordinates.x);
        roundCoordinates.y = Mathf.RoundToInt(rawCoordinates.y);
        return roundCoordinates;
    }
    // Raw World coordinates
    Vector2 MousePositionToWorldCoordinates()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;
        // ScreenToWorldPoint function parameter must be a Vector3
        Vector3 screenToWorldPointVector3 = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(screenToWorldPointVector3);
        return worldPos;
    }

}
