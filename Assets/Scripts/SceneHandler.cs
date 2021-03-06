using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneHandler : MonoBehaviour
{
	[SerializeField]
	private string gameScene;
	[SerializeField]
	private string mainMenuScene;
	[SerializeField]
	private string instructionsScene;
	[SerializeField]
	private string creditsScene;
	[SerializeField]
	private string endScene;
	[SerializeField]
	private string transitionScene;

	public void StartGame() => SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
	public void GoToInstructions() => SceneManager.LoadScene(instructionsScene, LoadSceneMode.Single);
	public void GoToCredits() => SceneManager.LoadScene(creditsScene, LoadSceneMode.Single);
	public void GoToMainMenu() => SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
	public void EndScreen() => SceneManager.LoadScene(endScene, LoadSceneMode.Single);

	public void TransitionToGame() => TransitionScene.TransitionToScene(gameScene);
	public void TransitionToEndScreen() => TransitionScene.TransitionToScene(endScene);

	public void ExitGame() => Application.Quit();
}
