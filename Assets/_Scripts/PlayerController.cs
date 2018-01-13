using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	RaycastHit2D m_Ray;
	float RAY_DISTANCE = 0f;

	Vector2 m_MousePos;

	bool m_CanLine = true;
	bool m_LineInstantiated = false;

	GameObject m_Tile;

	[SerializeField]
	LineRenderer m_Line;

	void Update()
	{
		if (Input.GetMouseButton(0) && m_CanLine)
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 localPos = new Vector2(worldPos.x, worldPos.y);
			m_MousePos = localPos;
			m_Ray = Physics2D.Raycast(localPos, Vector2.zero, RAY_DISTANCE);
			if (m_Ray.collider)
			{
				TileScript touchingTile = m_Ray.collider.GetComponent<TileScript>();
				m_Tile = touchingTile.gameObject;
				if (touchingTile.ReturnLit() && !m_LineInstantiated)
				{
					LineDrawn(true);
					Instantiate(m_Line, touchingTile.transform.position, touchingTile.transform.rotation);
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			CanLineTrue();
		}
	}

	public void CanLineTrue()
	{
		m_CanLine = true;
	}

	public void CanLineFalse()
	{
		m_CanLine = false;
	}

	public void LineDrawn(bool choice)
	{
		m_LineInstantiated = choice;
	}

	public Vector2 ReturnMousePosition()
	{
		return m_MousePos;
	}

	public GameObject ReturnTile()
	{
		return m_Tile;
	}
}
