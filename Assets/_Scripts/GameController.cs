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

	public WinLoseData m_WinLoseData;

	float TIME_TILL_NEXT_LEVEL = 3f;

	bool m_Win = false;
	bool m_XPass = false;
	bool m_YPass = false;

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

	//TODO: We need a way to remove the m_XPosDictionary key and m_YPosDictionarykey whenever we undo a line specifically.
	//At the moment, our game is does not take into account when we that we can undo lines.
	//So as its saving the x and y positions into dictionaries when a line is linked to a candle, when a line is undone, it doesn't remove the last position.
	//1) Obtain the element 0 of the line we are undoing.
	//2) create a remove from dictionary method, that takes in the x and y positions
	//3) Remove them from the dictionary

	public void RemoveList(int x, int y)
	{
		if (m_XPosDictionary.ContainsKey(x))
		{
			int xValue = m_XPosDictionary[x];
			m_XPosDictionary.Remove(x);
			xValue--;
			m_XPosDictionary.Add(x, xValue);
		}
		if (m_YPosDictionary.ContainsKey(y))
		{
			int yValue = m_YPosDictionary[y];
			m_YPosDictionary.Remove(y);
			yValue--;
			m_YPosDictionary.Add(y, yValue);
		}
	}


	public void Reset()
	{
		ClearList();
		m_WinLoseData.SetLevelFinished(false);
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
					if (m_XPosDictionary[x] > m_WinLoseData.m_MaxLineColumn[x])
					{
						m_XPass = false;
						CheckWin();
						return;
					}
				}
				else
				{
					m_XPass = true;
				}
			}
		}
		if (m_YPosDictionary.Count > 0)
		{
			for (int y = 0; y <= m_YPosDictionary.Count; y++)
			{
				if (m_YPosDictionary.ContainsKey(y))
				{
					if (m_YPosDictionary[y] > m_WinLoseData.m_MaxLineRow[y])
					{
						m_YPass = false;
						CheckWin();
						return;
					}
				}
				else
				{
					m_YPass = true;
				}
			}
		}
		CheckWin();
	}
	void CheckWin()
	{
		if (m_XPass && m_YPass)
		{
			Debug.Log("You Win");
			m_Win = true;
			StartCoroutine("NextLevel");
		}
		else if (!m_XPass || !m_YPass)
		{
			Lose();
		}
	}

	void Lose()
	{
		Debug.Log("You lose");
	}

	public bool ReturnWin()
	{
		return m_Win;
	}

	IEnumerator NextLevel()
	{
		yield return new WaitForSeconds(TIME_TILL_NEXT_LEVEL);

		LevelManager.instance.LoadNextLevel();
	}
}