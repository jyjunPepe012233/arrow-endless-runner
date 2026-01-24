using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartManager : MonoBehaviour
{
	public PlayerSquad playerSquad;
	public GameObject gameOverUi;

	private bool _isGameOvered = false;

	public void Start()
	{
		gameOverUi.SetActive(false);
	}

	public void Update()
	{
		if (playerSquad.unitCount <= 0 && !_isGameOvered)
		{
			_isGameOvered = true;
			GameOver();
		}
	}

	private void GameOver()
	{
		gameOverUi.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}
}