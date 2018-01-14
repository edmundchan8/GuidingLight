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
		LoadLevelInt(1);
	}

	IEnumerator StartTutorial()
	{
		yield return new WaitUntil(() => Input.anyKeyDown);
		Debug.Log("Using ints to load tutorials");
		LoadNextLevel();
	}

	public void LoadLevelInt(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex);
	}

	public void LoadNextLevel()
	{
		GameController.instance.Reset();
		Debug.Log("But how do we know this is the last level");
		SceneManager.LoadScene(ReturnCurrentScene() + 1);
	}

	public int ReturnCurrentScene()
	{
		return SceneManager.GetActiveScene().buildIndex;
	}

	public void RestartLevel()
	{
		GameController.instance.Reset();
		SceneManager.LoadScene(ReturnCurrentScene());
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