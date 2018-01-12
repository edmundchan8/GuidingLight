using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public static LevelManager instance;
	float LOAD_NEXT_SCENE_DURATION = 2f;
	GameObject m_Instructions;

	void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void Start()
	{
		if (ReturnCurrentScene() == 0)
		{
			StartCoroutine("LoadTitle");
		}
		else if (ReturnCurrentScene() == 1)
		{
			StartCoroutine("StartTutorial");
		}
	}

	IEnumerator LoadTitle()
	{
		yield return new WaitForSeconds(LOAD_NEXT_SCENE_DURATION);
		LoadLevel("Title");
	}

	IEnumerator StartTutorial()
	{
		yield return new WaitUntil(() => Input.anyKeyDown);
		LoadLevel("Tutorial01");
	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public int ReturnCurrentScene()
	{
		return SceneManager.GetActiveScene().buildIndex;
	}

	/*
	IEnumerator ReloadScene()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnGameOverPanel().GameOver());
		yield return new WaitForSeconds(LOAD_NEXT_SCENE_DURATION);
		LoadLevel("Game");
	}

	IEnumerator LoadWin()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnGameOverPanel().Win());
		yield return new WaitForSeconds(LOAD_NEXT_SCENE_DURATION);
		LoadLevel("Win");
	}
*/

	/*
	public void StartNewGame()
	{
		SceneManager.LoadScene("Game");
	}
*/
}