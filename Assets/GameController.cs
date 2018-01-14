using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public static GameController instance;

	Dictionary <int, int> m_XPosDictionary = new Dictionary <int, int>();
	Dictionary <int, int> m_YPosDictionary = new Dictionary <int, int>();

	Vector2 m_EntrancePos;
	Vector2 m_ExitPos;

	void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void ClearList()
	{
		m_XPosDictionary.Clear();
		m_YPosDictionary.Clear();
	}

	public void AddList(int x, int y)
	{
		if (!m_XPosDictionary.ContainsKey(x))
		{
			m_XPosDictionary.Add(x, 1);
		}
		else
		{
			int value = m_XPosDictionary[x];
			m_XPosDictionary.Remove(x);
			value ++;
			m_XPosDictionary.Add(x, value);
		}

		//Not sure why the Y Position is increasing.
		//The list is increasng
		//It should be, 1 element there = 0 
		//0 should have a value of 2/3
		//dictionary?
		if (!m_YPosDictionary.ContainsKey(y))
		{
			m_YPosDictionary.Add(y, 1);
		}
		else
		{
			int value = m_YPosDictionary[y];
			m_YPosDictionary.Remove(y);
			value++;
			m_YPosDictionary.Add(y, value);
		}
	}

	public void Reset()
	{
		ClearList();
	}

	public void TrackEntranceExitPos(Vector2 entrance, Vector2 exit)
	{
		//Track entrance and exit pos from BoardController
		m_EntrancePos = entrance;
		m_ExitPos = exit;
	}

	public Vector2 ReturnEntrancePos()
	{
		return m_EntrancePos;
	}

	public Vector2 ReturnExitPos()
	{
		return m_ExitPos;
	}

	public void CheckLines()
	{
		if (m_XPosDictionary.Count > 0)
		{
			for (int x = 0; x <= m_XPosDictionary.Count; x++)
			{
				if (m_XPosDictionary.ContainsKey(x))
				{
					Debug.Log("When X = " + x + " , you have crossed it " + m_XPosDictionary[x] + " times.");
				}
			}
		}
		else
		{
			return;
		}
		if (m_YPosDictionary.Count > 0)
		{
			for (int y = 0; y <= m_YPosDictionary.Count; y++)
			{
				if (m_YPosDictionary.ContainsKey(y))
				{
					Debug.Log("When Y = " + y + " , you have crossed it " + m_YPosDictionary[y] + " times.");
				}
			}
		}
		else
		{
			return;
		}
	}
}
