using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Screen _restartScreen;
    [SerializeField] private Screen _victoryScreen;
    [SerializeField] private Cake _templateCake;

    private void Start()
    {
        _player.Died += _restartScreen.Open;
        _enemy.Died += OnRewardPlayer;
    }

    private void OnDisable()
    {
        _player.Died -= _restartScreen.Open;
        _enemy.Died -= OnRewardPlayer;
    }

    public void Restart()
    {
        _player.transform.position = _startPoint.position;
        _restartScreen.Close();
        _player.SwichOnPlayer();
    }

    public void OnRewardPlayer()
    {
        var cake = Instantiate(_templateCake,_enemy.transform.position, _enemy.transform.rotation);
        cake.Ate += _victoryScreen.Open;
    }
}
