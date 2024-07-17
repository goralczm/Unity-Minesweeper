using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class EndScreen : Singleton<EndScreen>
{
    [Header("Settings")]
    [SerializeField] private UnityEvent _onEndActions;

    [Header("Instances")]
    [SerializeField] private TextMeshProUGUI _text;

    public void Win()
    {
        _text.SetText("<color=green>You won!</color>");
        End();
    }

    public void Lose()
    {
        _text.SetText("<color=red>You lost!</color>");
        End();
    }

    private void End()
    {
        _onEndActions?.Invoke();
    }

    public void Restart()
    {
        Helpers.RestartLevel();
    }
}