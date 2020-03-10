using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	[SerializeField] Color exploredColor;
	public bool isExplored = false;
	private const int gridSize = 10;
	public WayPoint exploredFrom;

	Vector2Int gridPos;


	//void Update()
	//{
	//	if(isExplored)
	//	{
	//		SetColour(exploredColor);
	//	}
	//}
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
	public void SetColour(Color col)
	{
		MeshRenderer meshrend = transform.Find("Top").GetComponent<MeshRenderer>();
		meshrend.material.color = col;
	}
}
