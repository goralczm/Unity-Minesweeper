using System.Collections.Generic;
using System.Linq;
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

    public static void Shuffle<T>(this IList<T> l)
    {
        int size = l.Count();

        for (int i = 0; i < size / 2f; i++)
        {
            int firstIndex = Random.Range(0, size);
            int secondIndex = Random.Range(0, size);

            l.Swap(firstIndex, secondIndex);
        }
    }

    public static void Swap<T>(this IList<T> l, int firstIndex, int secondIndex)
    {
        T tmp = l[firstIndex];
        l[firstIndex] = l[secondIndex];
        l[secondIndex] = tmp;
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}