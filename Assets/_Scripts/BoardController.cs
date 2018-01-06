using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour 
{
	List<int> m_XPosList = new List<int>();
	List<int> m_YPosList = new List<int>();

	public void AddXList (int element)
	{
		m_XPosList.Add(element);
	}

	public void AddYList (int element)
	{
		m_YPosList.Add(element);
	}

	public void ClearXList()
	{
		m_XPosList.Clear();
	}

	public void ClearYList()
	{
		m_YPosList.Clear();
	}
}
