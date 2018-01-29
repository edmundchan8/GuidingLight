using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImage : MonoBehaviour 
{
	[SerializeField]
	ScreenImageData m_ScreenImageData;
	Transform m_BackgroundImage;
	Image m_Image;
	float DISABLE_DURATION = 3f;
	GameObject m_RestartButton;
	GameObject m_TitleButton;

	void Start () 
	{
		m_BackgroundImage = gameObject.transform.GetChild(0);	
		m_Image = m_BackgroundImage.transform.GetChild(0).GetComponent<Image>();
		FindButton();
		m_TitleButton.SetActive(false);
		m_RestartButton.SetActive(false);
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[0];
		StartCoroutine("DisableImage");
		StartCoroutine("LevelFinished");
	}

	public void OnWin()
	{
		EnableImage();
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[1];
	}

	public void OnLose()
	{
		EnableImage();
		m_RestartButton.gameObject.SetActive(true);
		m_TitleButton.gameObject.SetActive(true);
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[2];
	}

	void EnableImage()
	{
		m_BackgroundImage.gameObject.SetActive(true);
	}

	IEnumerator DisableImage()
	{
		yield return new WaitForSeconds(DISABLE_DURATION);
		m_BackgroundImage.gameObject.SetActive(false);
	}

	IEnumerator LevelFinished()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnLevelClear());
		if (!GameController.instance.ReturnWin())
		{
			OnLose();
		}
		else if (GameController.instance.ReturnWin())
		{
			OnWin();
		}
		Debug.Log("Level Finished");
	}

	void FindButton()
	{
		m_RestartButton = GameObject.FindGameObjectWithTag("RestartOnLose");
		m_TitleButton = GameObject.FindGameObjectWithTag("TitleButton");
	}
}
