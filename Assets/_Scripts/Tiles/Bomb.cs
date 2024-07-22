using UnityEngine;
using Utilities.AudioSystem;

public class Bomb : Tile
{
    public override string Name => "Bomb";

    [SerializeField] private Sprite _bombSprite;

    private Sprite _defaultSprite;

    private void Start()
    {
        _defaultSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.H))
        {
            if (_rend.sprite != _bombSprite)
                _defaultSprite = _rend.sprite;

            _rend.sprite = _bombSprite;
        }
        else if (Input.GetKeyUp(KeyCode.H))
            _rend.sprite = _defaultSprite;
#endif
    }

    public override void OnLeftClickAction()
    {
        StartCoroutine(_tilesManager.ExplosionSequence());

        EndScreen.Instance.Lose();
    }

    public void Explode()
    {
        _rend.sprite = _bombSprite;
        AudioSystem.Instance.PlaySoundFromGroup("sfx", "explosion");
        IsShown = true;
    }
}