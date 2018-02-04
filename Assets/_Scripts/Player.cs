using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	PlayerController m_PlayerController;

	Stack<LineRenderer> m_ObtainedStack = new Stack<LineRenderer>();
	Stack<LineRenderer> m_UsingStack = new Stack<LineRenderer>();

	bool m_CanMove = false;

	Timer m_MoveTimer = new Timer();

	float MOVE_DURATION = 0.5f;

	Vector3 m_StartPos;
	Vector3 m_EndPos;

	void Awake()
	{
		m_PlayerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
	}
		
	void FixedUpdate()
	{
		m_MoveTimer.Update(Time.deltaTime);
		if (m_CanMove)
		{
			float moveTime = (MOVE_DURATION - m_MoveTimer.GetTime()) / MOVE_DURATION;
			transform.position = Vector3.Lerp(m_StartPos, m_EndPos, moveTime);
			if (transform.position == m_EndPos)
			{
				if (m_UsingStack.Count <= 0)
				{
					m_CanMove = false;
					GameController.instance.CheckLines();
					return;
				}
				else if (m_MoveTimer.HasCompleted())
				{
					m_StartPos = transform.position;
					Vector2 endPos = m_UsingStack.Pop().GetPosition(0);
					m_EndPos = new Vector3(m_StartPos.x + endPos.x, m_StartPos.y + endPos.y, 0);
					m_MoveTimer.SetTime(MOVE_DURATION);
				}
			}
		}

	}

	//reverse objects in line stack
	public void GetLineStack()
	{
		m_ObtainedStack = m_PlayerController.ReturnLineStack();
		ReverseLineStack();
	}

	void ReverseLineStack()
	{
		int stackLength = m_ObtainedStack.Count;
		for (int i = 0; i <= stackLength; i++)
		{
			if (m_ObtainedStack.Count > 0)
			{
				m_UsingStack.Push(m_ObtainedStack.Pop());
			}
		}
		SetFirstStartEndPos();
	}

	//read each line position and debug it out
	void SetFirstStartEndPos()
	{
		if (!m_CanMove)
		{
			GameObject startObj = GameObject.FindGameObjectWithTag("Entrance");
			Vector2 endPos = new Vector2(startObj.transform.position.x, startObj.transform.position.y);
			m_MoveTimer.SetTime(MOVE_DURATION);
			m_StartPos = transform.position;
			m_EndPos = endPos;
			m_CanMove = true;
		}
	}
}