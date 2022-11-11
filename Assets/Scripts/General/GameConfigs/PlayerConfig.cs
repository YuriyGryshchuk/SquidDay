using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    [SerializeField] private float _timeOfImmortalityOnDamage;
    [SerializeField] private float _playerPushForce = 3f;
    [SerializeField] private float _slowdownVelosity = 0.1f;
    [SerializeField] private float _timeWithoutMove = 1f;
    [SerializeField] private GameObject _playerProjectile;
    [SerializeField] private float _speedToRotatePlayer = 20;

    public int PlayerHealth => _playerHealth;
    public float TimeOfImmortalityOnDamage => _timeOfImmortalityOnDamage;
    public float PlayerPushForce => _playerPushForce;
    public float SlowdownVelosity => _slowdownVelosity;
    public float TimeWithoutMove => _timeWithoutMove;
    public GameObject PlayerProjectile => _playerProjectile;
    public float SpeedToRotatePlayer => _speedToRotatePlayer;
}
