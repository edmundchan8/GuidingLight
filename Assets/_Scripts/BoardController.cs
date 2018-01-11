using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour 
{
	Dictionary<int, int> m_XPosDictionary = new Dictionary<int, int>();
	Dictionary<int, int> m_YPosDictionary = new Dictionary<int, int>();

	public RowData[] m_RowData;

	void Start()
	{
		CreateBoard();
	}

	public void CreateBoard()
	{
		for (int y = 0; y < m_RowData.Length; y++)
		{
			for (int x = 0; x < m_RowData[y].m_Tiles.Length; x++)
			{
				GameObject tile = Instantiate(m_RowData[y].m_Tiles[x], transform.position, transform.rotation) as GameObject;
				Vector2 pos = new Vector2(tile.transform.position.x, tile.transform.position.y);
				pos.x = x;
				pos.y = y;
				tile.transform.position = pos;
			}
		}
	}

	public void AddXDictionary (int element, int value)
	{
		m_XPosDictionary.Add(element, value);
	}

	public void AddYDictionary (int element, int value)
	{
		m_YPosDictionary.Add(element, value);
	}

	public void ClearXList()
	{
		m_XPosDictionary.Clear();
	}

	public void ClearYList()
	{
		m_YPosDictionary.Clear();
	}
}
