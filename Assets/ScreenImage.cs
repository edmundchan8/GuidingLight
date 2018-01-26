using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImage : MonoBehaviour 
{
	[SerializeField]
	ScreenImageData m_ScreenImageData;
	Image m_Image;

	float DISABLE_DURATION = 3f;

	void Start () 
	{
		m_Image = GetComponent<Image>();
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[0];
		StartCoroutine("DisableImage");
	}

	public void OnWin()
	{
		EnableThenDisableImage();
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[1];
	}

	public void OnLose()
	{
		EnableThenDisableImage();
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[2];
	}

	void EnableThenDisableImage()
	{
		m_Image.enabled = true;
		StartCoroutine("DisableImage");
	}

	IEnumerator DisableImage()
	{
		yield return new WaitForSeconds(DISABLE_DURATION);
		m_Image.enabled  = false;
	}
}
