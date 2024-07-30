using UnityEngine;
using Utilities.AudioSystem;

public class Bomb : Tile
{
    public override string Name => "Bomb";

    [SerializeField] private GameObject _bomb;

    public override void OnLeftClickAction()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(_tilesManager.ExplosionSequence());

        EndScreen.Instance.Lose();
    }

    public void Explode()
    {
        _bomb.SetActive(true);
        AudioSystem.Instance.PlaySoundFromGroup("effects", "explosion");
        IsShown = true;
    }
}