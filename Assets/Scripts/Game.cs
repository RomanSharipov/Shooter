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
        _player.Die += _restartScreen.Open;
        _enemy.Die += RewardPlayer;
    }

    private void OnDisable()
    {
        _player.Die -= _restartScreen.Open;
        _enemy.Die -= RewardPlayer;
    }

    public void Restart()
    {
        _player.transform.position = _startPoint.position;
        _restartScreen.Close();
        _player.SwichOnPlayer();
    }

    public void RewardPlayer()
    {
        var cake = Instantiate(_templateCake,_enemy.transform.position, _enemy.transform.rotation);
        cake.OnEat += _victoryScreen.Open;
    }
}
