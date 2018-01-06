using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour 
{
	bool m_Lit = false;

	public void Light()
	{
		m_Lit = true;
	}

	public bool ReturnLit()
	{
		return m_Lit;
	}
}
