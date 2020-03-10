using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	[SerializeField] Color exploredColor;
	public bool isExplored = false;
	private const int gridSize = 10;
	public WayPoint exploredFrom;
	public bool isPlaceable = true;
	Vector2Int gridPos;

	public int GetSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
					Mathf.RoundToInt(transform.position.x / gridSize),
					Mathf.RoundToInt(transform.position.z / gridSize)
			);
	}
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0) && isPlaceable)
		{
		print(gameObject.name);
		}
	}
}
