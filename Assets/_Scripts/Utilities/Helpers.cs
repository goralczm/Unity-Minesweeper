using UnityEngine;
using UnityEngine.SceneManagement;

public static class Helpers
{
    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }

    public static bool IsBomb(this GameObject g)
    {
        return g.GetComponent<Bomb>() == null ? false : true;
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}