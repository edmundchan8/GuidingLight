using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour 
{
	bool m_Lit = false;

	public void Light(bool choice)
	{
		m_Lit = choice;
	}

	public bool ReturnLit()
	{
		return m_Lit;
	}
}
