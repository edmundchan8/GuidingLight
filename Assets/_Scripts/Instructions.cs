using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour 
{
	[SerializeField]
	InstructionData m_InstructionaData;
	bool m_InstructionsOn = true;

	int m_CurrentSprite = 0;
	[SerializeField]
	Image m_Image;

	void Start()
	{
		gameObject.SetActive(true);
		m_Image.sprite = m_InstructionaData.LoadSprite(m_CurrentSprite);
	}

	//TODO Thinking of using this to confirm if we can play the game, but this only works if m_InstructionData SO in every scene (which it currently isn't)
	public bool ReturnInstructionsActive()
	{
		return m_InstructionsOn;
	}

	public void OnNextButton()
	{
		if (m_CurrentSprite < (m_InstructionaData.m_SpriteArray.Length - 1))
		{
			m_CurrentSprite++;
			m_Image.sprite = m_InstructionaData.LoadSprite(m_CurrentSprite);
		}
		else
			return;
	}

	public void OnRepeatButton()
	{
		m_CurrentSprite = 0;
		m_Image.sprite = m_InstructionaData.LoadSprite(m_CurrentSprite);
	}

	public void OnEndButton()
	{
		m_InstructionsOn = false;
		gameObject.SetActive(false);
	}
}
