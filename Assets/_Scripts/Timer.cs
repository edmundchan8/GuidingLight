using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	float m_Time;

	public void SetTime(float time)
	{
		m_Time = time;
	}

	public bool Update(float tick)
	{
		if (m_Time > 0.0f)
		{
			m_Time = Mathf.Max(m_Time - tick, 0.0f);
			if (m_Time <= 0.0f)
			{
				return true;
			}
		}
		return false;
	}


	public float GetTime()
	{
		return m_Time;
	}

	public bool HasCompleted()
	{
		return m_Time <= 0f;
	}
}
