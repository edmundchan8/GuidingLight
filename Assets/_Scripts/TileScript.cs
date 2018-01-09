using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour 
{
	bool m_Lit = false;

	void Awake()
	{
		if (gameObject.tag == "Entrance")
		{
			Light(true);
		}
	}

	public void Light(bool choice)
	{
		m_Lit = choice;
	}

	public bool ReturnLit()
	{
		return m_Lit;
	}

	public Vector2 ReturnTilePos()
	{
		return new Vector2(transform.position.x, transform.position.y);
	}

	public void DisableCollider()
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
}
