using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour 
{
	float TIME_TILL_NEXT_LEVEL = 3f;

	bool m_Lit = false;

	[SerializeField]
	GameObject m_Highlight;

	void Awake()
	{
		if (gameObject.tag == "Entrance")
		{
			Light(true);
		}
		m_Highlight.SetActive(false);
		if (gameObject.tag == "Exit")
		{
			StartCoroutine("OnExitLit");
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
		Debug.Log("You Win");
		yield return new WaitForSeconds(TIME_TILL_NEXT_LEVEL);
		LevelManager.instance.LoadNextLevel();
	}
}
