using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private GenerationProcess _generator;

    public void PlayBeginner()
    {
        _generator.MakeBoard(8, 8, 10);
    }

    public void PlayIntermediate()
    {
        _generator.MakeBoard(16, 16, 40);
    }

    public void PlayExpert()
    {
        _generator.MakeBoard(30, 16, 99);
    }
}
