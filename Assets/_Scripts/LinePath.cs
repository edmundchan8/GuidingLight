using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePath : MonoBehaviour 
{
	[SerializeField]
	PlayerController m_PlayerController;

	[SerializeField]
	LineRenderer m_Line;

	Vector2 m_CurrentPos;

	void Awake()
	{
		m_PlayerController = FindObjectOfType<PlayerController>();
		m_CurrentPos = new Vector2(transform.position.x, transform.position.y);
	}

	void Update () 
	{
		Vector2 linePos = m_PlayerController.ReturnMousePosition() - m_CurrentPos;
		m_Line.SetPosition(0, linePos);
	}
}
