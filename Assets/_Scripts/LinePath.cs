using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePath : MonoBehaviour 
{
	[SerializeField]
	PlayerController m_PlayerController;

	[SerializeField]
	LineRenderer m_Line;

	Vector2 m_CurrentTilePos;
	Vector2 m_EndTilePos;

	bool m_CanDraw;

	float m_MaxLength = 1.1f;

	void Awake()
	{
		m_PlayerController = FindObjectOfType<PlayerController>();
		GameObject tile = m_PlayerController.ReturnTile();
		m_CurrentTilePos = new Vector2(tile.transform.position.x, tile.transform.position.y);
		m_CanDraw = true;
	}

	void Update () 
	{
		if (m_CanDraw)
		{
			Vector2 linePos = m_PlayerController.ReturnMousePosition() - m_CurrentTilePos;
			m_Line.SetPosition(0, linePos);
			float lineX = m_Line.GetPosition(0).x;
			float lineY = m_Line.GetPosition(0).y;

			if (lineX > m_MaxLength || lineY > m_MaxLength || lineX < -m_MaxLength || lineY < -m_MaxLength)
			{
				m_CanDraw = false;
			}
		}
	}
}
