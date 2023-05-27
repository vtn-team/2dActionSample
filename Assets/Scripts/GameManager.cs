using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager
{
    static GameManager _instance = new GameManager();
    public static GameManager Instance => _instance;
    private GameManager() { }


    Player _player;
    List<Enemy> _enemies = new List<Enemy>();

    public Player Player => _player;
    public List<Enemy> Enemies => _enemies;

    public void Register(Player p) { _player = p; }
    public void Register(Enemy e) { _enemies.Add(e); }
    public void Remove(Enemy e) { _enemies.Remove(e); }

    bool _hitStop = false;
    float _timer = 0.0f;

    public void HitStop(float time)
    {
        _timer = time;
        Time.timeScale = 0;
    }
    public void UpdateHitStop()
    {
        if (Time.timeScale > 0) return;

        _timer -= Time.unscaledDeltaTime;
        if(_timer < 0.0f)
        {
            Time.timeScale = 1.0f;
        }
    }
}
