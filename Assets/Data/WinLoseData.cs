using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WinLoseData : ScriptableObject 
{
	public int[] m_MaxLineRow;
	public int[] m_MaxLineColumn;

	public bool m_LevelFinished = false;

	public void SetLevelFinished(bool choice)
	{
		m_LevelFinished = choice;
	}

	public bool ReturnLevelFinished()
	{
		return m_LevelFinished;
	}
}
