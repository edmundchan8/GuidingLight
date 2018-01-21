using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UndoScript : MonoBehaviour 
{
	PlayerController m_PlayerController;

	void Start()
	{
		m_PlayerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
	}
	public void OnClick()
	{
		if (!GameController.instance.ReturnWin())
		{
			m_PlayerController.UndoLine();
		}
	}
}
