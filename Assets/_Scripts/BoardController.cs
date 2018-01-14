using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour 
{
	public RowData[] m_RowData;

	Vector2 m_EntrancePos;
	Vector2 m_ExitPos;

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
				GameObject tile = Instantiate(m_RowData[y].m_Tiles[x], transform.position, transform.rotation, gameObject.transform) as GameObject;
				Vector2 pos = new Vector2(tile.transform.position.x, tile.transform.position.y);
				pos.x = x;
				pos.y = y;
				tile.transform.position = pos;
				if (tile.tag == "Entrance")
				{
					m_EntrancePos = pos;
				}
				else if (tile.tag == "Exit")
				{
					m_ExitPos = pos;
				}
			}
		}
		GameController.instance.TrackEntranceExitPos(m_EntrancePos, m_ExitPos);
	}


}
