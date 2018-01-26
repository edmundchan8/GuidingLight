using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoard : MonoBehaviour 
{
	public WinLoseData m_WinLoseData;

	float IncrementCameraPosValue = 0.5f;

	void Start()
	{
		float xPos = (m_WinLoseData.m_MaxLineColumn.Length - 1) * IncrementCameraPosValue;
		float yPos = (m_WinLoseData.m_MaxLineRow.Length - 1) * IncrementCameraPosValue;

		transform.position = new Vector3(xPos, yPos, transform.position.z);
	}
}
