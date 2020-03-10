using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[ExecuteInEditMode]
	[SelectionBase]
	[RequireComponent(typeof(WayPoint))]
	public class CubeEditor : MonoBehaviour
	{
		WayPoint waypoint;
	
	void Update()
	{
		SnapCube();
		LabelCube();
	}

	private void SnapCube()
	{
		int gridSize = waypoint.GetSize();
		transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0, waypoint.GetGridPos().y * gridSize);
	}

	private void LabelCube()
	{
		string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;

		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		textMesh.text = labelText;

		gameObject.name = labelText;
	}

	void Awake()
	{
		waypoint = GetComponent<WayPoint>();
	}
	}

