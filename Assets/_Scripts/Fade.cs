using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour 
{
	float m_FadeInTimer;
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
		if(m_FadeInTimer < m_FadeDuration)
		{
			m_FadeInTimer += Time.fixedDeltaTime;
			Color color = m_Sprite.GetComponent<SpriteRenderer>().color;
			float alpha = m_FadeInTimer / m_FadeDuration;
			color.a = alpha;
			m_Sprite.GetComponent<SpriteRenderer>().color = color;
		}

		if (GameController.instance.ReturnLevelClear() && GameController.instance.ReturnWin())
		{
			if (m_Sprite.color.a > 0f)
			{
				m_Sprite.color = Color.Lerp(m_Sprite.color, Color.clear, m_FadeDuration * Time.deltaTime);
			}
		}
	}
}
