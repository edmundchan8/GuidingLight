using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour 
{
	bool m_Lit = false;

	[SerializeField]
	GameObject m_Highlight;

	[SerializeField]
	GameObject m_CandleAnimationSprite;

	Player m_Player;

	void Awake()
	{
		if (gameObject.tag == "Entrance")
		{
			Light(true);
		}
		m_Highlight.SetActive(false);
		if (gameObject.tag == "Exit")
		{
			m_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			StartCoroutine("OnExitLit");
		}
		if (!m_Lit)
		{
			DisableCandleAnimationSprite();
		}
	}

	public void Light(bool choice)
	{
		m_Lit = choice;
		if (m_Lit)
		{
			ReenableCandleAnimationSprite();
		}
		else
		{
			DisableCandleAnimationSprite();
		}
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

	public void ReenableCollider()
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void DisableCandleAnimationSprite()
	{
		m_CandleAnimationSprite.SetActive(false);
	}

	public void ReenableCandleAnimationSprite()
	{
		m_CandleAnimationSprite.SetActive(true);
	}

	public void OnMouseOver()
	{
		m_Highlight.SetActive(true);
	}

	public void OnMouseExit()
	{
		m_Highlight.SetActive(false);
	}

	public bool TileCheck(Vector2 currentTile, Vector2 nextTile)
	{
		Vector2 tileUp = new Vector2(currentTile.x, currentTile.y + 1);
		Vector2 tileRight = new Vector2(currentTile.x +1, currentTile.y);
		Vector2 tileDown = new Vector2(currentTile.x, currentTile.y - 1);
		Vector2 tileLeft = new Vector2(currentTile.x - 1, currentTile.y);

		if (nextTile == tileUp)
		{
			return true;
		}
		else if (nextTile == tileRight)
		{
			return true;
		}
		else if (nextTile == tileDown)
		{
			return true;
		}
		else if (nextTile == tileLeft)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator OnExitLit()
	{
		yield return new WaitUntil(() => ReturnLit());
		m_Player.GetLineStack();
		//TODO: This will be called once player reaches last tile now.
		//GameController.instance.CheckLines();
	}
}
