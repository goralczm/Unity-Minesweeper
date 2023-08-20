public class EndScreen : Singleton<EndScreen>
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        Helpers.RestartLevel();
    }
}