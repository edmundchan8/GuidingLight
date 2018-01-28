using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	PlayerController m_PlayerController;

	Stack<LineRenderer> m_ObtainedStack = new Stack<LineRenderer>();
	Stack<LineRenderer> m_UsingStack = new Stack<LineRenderer>();
	//Obtain LineStack from PlayerController
	void Awake()
	{
		m_PlayerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
	}
		
	//reverse objects in line stack
	public void GetLineStack()
	{
		m_ObtainedStack = m_PlayerController.ReturnLineStack();
		ReverseLineStack();
	}

	void ReverseLineStack()
	{
		for (int i = 0; i <= m_ObtainedStack.Count; i++)
		{
			m_UsingStack.Push(m_ObtainedStack.Pop());
		}
		ReadUsingStack();
	}

	//read each line position and debug it out
	void ReadUsingStack()
	{
		for (int i = 0; i <= m_UsingStack.Count; i++)
		{
			LineRenderer line = m_UsingStack.Pop();
			Vector2 pos = line.GetComponent<LineRenderer>().GetPosition(0);
			Debug.Log(pos);
		}
	}
}
