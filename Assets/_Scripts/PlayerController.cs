using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	RaycastHit2D m_Ray;
	float RAY_DISTANCE = 1f;

	Vector2 m_MousePos;

	bool m_InPlay = false;

	[SerializeField]
	LineRenderer m_Line;

	void Update()
	{
		if (Input.GetMouseButton(0) && !m_InPlay)
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 localPos = new Vector2(worldPos.x, worldPos.y);
			m_MousePos = localPos;
			m_Ray = Physics2D.Raycast(localPos, Vector2.zero, RAY_DISTANCE);
			if (m_Ray.collider)
			{
				TileScript tile = m_Ray.collider.GetComponent<TileScript>();
				if (!tile.ReturnLit())
				{
					Debug.Log("Begin rendering line");
					Instantiate(m_Line, tile.transform.position, tile.transform.rotation);
					//line.SetPosition(0, tile.transform.position);
					tile.Light();
				}
			}

			//TODO later
			//if(condition where rules are broken (touching candle too far from last point)) { m_InPlay = true;}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			InPlayFalse();
		}
	}

	public void InPlayFalse()
	{
		m_InPlay = false;
	}

	public Vector2 ReturnMousePosition()
	{
		return m_MousePos;
	}
}
