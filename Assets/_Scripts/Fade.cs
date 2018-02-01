using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour 
{
	float m_Timer;
	[SerializeField]
	float m_FadeDuration;

	SpriteRenderer m_Sprite;
	Color m_Color;

	void Awake()
	{
		m_Sprite = GameObject.FindObjectOfType<SpriteRenderer>();
		m_Color = m_Sprite.GetComponent<SpriteRenderer>().color;
		float alpha = 0;
		m_Color.a = alpha;
		m_Sprite.GetComponent<SpriteRenderer>().color = m_Color;
	}

	void Update()
	{
		if(m_Timer < m_FadeDuration)
		{
			m_Timer += Time.fixedDeltaTime;
			Color color = m_Sprite.GetComponent<SpriteRenderer>().color;
			float alpha = m_Timer / m_FadeDuration;
			color.a = alpha;
			m_Sprite.GetComponent<SpriteRenderer>().color = color;
		}
	}
}
