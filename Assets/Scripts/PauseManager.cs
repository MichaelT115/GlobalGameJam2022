using System;
using UnityEngine;

public sealed class PauseManager : MonoBehaviour
{
	[SerializeField]
	private bool isPaused;

	public static event Action<bool> OnPauseUpdate;

	public bool IsPaused
	{
		get => isPaused; private set
		{
			isPaused = value;
			Time.timeScale = IsPaused ? 0 : 1;
			OnPauseUpdate?.Invoke(isPaused);
		}
	}

	private void Update()
	{
		if (HasTogglePause)
		{
			IsPaused = !IsPaused;
		}
	}

    private void OnDestroy()
    {
		Time.timeScale = 1;
    }

    private static bool HasTogglePause
		=> Input.GetButtonDown("Pause");
}
