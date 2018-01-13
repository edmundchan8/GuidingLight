using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public static GameController instance;

	int m_NumberLines = 0;

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

	public void ResetLineCount()
	{
		m_NumberLines = 0;
	}

	public void TrackLineObjects()
	{
		//Just track the number of valid line objects first.
		m_NumberLines++;
	}

	public void CheckLines()
	{
		Debug.Log("You have used " + m_NumberLines + " lines.");
	}
}
