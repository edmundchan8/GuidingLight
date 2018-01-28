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

	void Start () 
	{
		m_BackgroundImage = gameObject.transform.GetChild(0);	
		m_Image = m_BackgroundImage.transform.GetChild(0).GetComponent<Image>();
		m_Image.sprite = m_ScreenImageData.m_ScreenSpriteArray[0];
		StartCoroutine("DisableImage");
		StartCoroutine("LevelFinished");
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
		m_BackgroundImage.gameObject.SetActive(true);
		StartCoroutine("DisableImage");
	}

	IEnumerator DisableImage()
	{
		yield return new WaitForSeconds(DISABLE_DURATION);
		m_BackgroundImage.gameObject.SetActive(false);
	}

	IEnumerator LevelFinished()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnWin());
		EnableThenDisableImage();
		Debug.Log("Level Finished");
	}
}
