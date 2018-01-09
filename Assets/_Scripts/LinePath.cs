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

	GameObject m_CurrentTile;
	GameObject m_NextTile;

	bool m_CanDraw;

	float m_MaxLength = 1.1f;

	void Awake()
	{
		m_PlayerController = FindObjectOfType<PlayerController>();
		m_CurrentTile = m_PlayerController.ReturnTile();
		m_CurrentTilePos = new Vector2(m_CurrentTile.transform.position.x, m_CurrentTile.transform.position.y);
		m_EndTilePos = m_CurrentTilePos;
		m_CanDraw = true;
		StartCoroutine("OverOtherCandle");
	}

	void Update () 
	{
		//Can only draw a line is the current tile is not lit
		if (m_CanDraw)
		{
			Vector2 linePos = (m_PlayerController.ReturnMousePosition() - m_CurrentTilePos);
			m_Line.SetPosition(0, linePos);
			float lineX = m_Line.GetPosition(0).x;
			float lineY = m_Line.GetPosition(0).y;

			Debug.Log(m_PlayerController.ReturnTile().transform.position);

			if (lineX > m_MaxLength || lineY > m_MaxLength || lineX < -m_MaxLength || lineY < -m_MaxLength)
			{
				//TODO - set the light on the tilescript to be false
				m_PlayerController.ReturnTile().GetComponent<TileScript>().Light(false);
				Destroy(gameObject);
			}
		}
	}

	IEnumerator OverOtherCandle()
	{
		yield return new WaitUntil(() => new Vector2 (m_PlayerController.ReturnTile().transform.position.x, m_PlayerController.ReturnTile().transform.position.y) != m_CurrentTilePos);
		m_CurrentTile.GetComponent<TileScript>().DisableCollider();
		m_NextTile = m_PlayerController.ReturnTile();
		m_EndTilePos = m_PlayerController.ReturnMousePosition() - m_NextTile.GetComponent<TileScript>().ReturnTilePos();
		m_Line.SetPosition(0, m_NextTile.transform.position - m_CurrentTile.transform.position);
		m_CanDraw = false;
	}


}
