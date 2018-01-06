using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	RaycastHit2D m_Ray;
	float RAY_DISTANCE = 1f;

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 localPos = new Vector2(worldPos.x, worldPos.y);
			m_Ray = Physics2D.Raycast(localPos, Vector2.down, RAY_DISTANCE);
			if (m_Ray.collider)
			{
				Tile tile = m_Ray.collider.GetComponent<Tile>();
				if (!tile.ReturnLit())
				{
					Debug.Log(m_Ray.collider.tag);
					Debug.Log(m_Ray.transform.position);
					tile.Light();
				}
			}
		}
	}
}
