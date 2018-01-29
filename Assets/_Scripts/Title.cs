using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour 
{
	public void ReturnMenu()
	{
		LevelManager.instance.LoadLevelInt(1);
	}
}
