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

	public WinLoseData m_WinLoseData;

	[SerializeField]
	GameObject m_Player;

	GameObject player;

	GameObject m_Tile;

	[SerializeField]
	LineRenderer m_Line;

	Stack<LineRenderer> m_LineStack = new Stack<LineRenderer>();
	Stack<GameObject> m_TileStack = new Stack<GameObject>();

	void Awake()
	{
		player = Instantiate(m_Player, transform.position, transform.rotation);
	}

	void Start()
	{
		player.transform.position = GameController.instance.ReturnStairPos();
	}

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
				if (touchingTile.ReturnLit() && !m_LineInstantiated && touchingTile.tag != "Exit")
				{
					LineDrawn(true);
					LineRenderer line = Instantiate(m_Line, touchingTile.transform.position, touchingTile.transform.rotation, gameObject.transform) as LineRenderer;
					m_LineStack.Push(line);
					if (m_TileStack.Count < 1 || m_TileStack.Peek() != m_Tile)
					{
						m_TileStack.Push(m_Tile);
					}
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

	public void PopLineFromStack()
	{
		m_LineStack.Pop();
	}

	public void UndoLine()
	{
		if(m_LineStack.Count > 1 && !m_WinLoseData.ReturnLevelFinished())
		{
			LineDrawn(false);
			if (m_LineStack.Count < m_TileStack.Count)
			{
				GameObject tempTile = m_TileStack.Pop();
				tempTile.GetComponent<TileScript>().Light(false);
				GameObject previousTile = m_TileStack.Pop();
				previousTile.GetComponent<TileScript>().ReenableCollider();
				m_TileStack.Push(previousTile);
			}
			LineRenderer line = m_LineStack.Pop();
			GameController.instance.RemoveList((int)line.transform.position.x, (int)line.transform.position.y);
			Destroy(line.gameObject);
		}
	}

	public Stack<LineRenderer> ReturnLineStack()
	{
		return m_LineStack;
	}
}
