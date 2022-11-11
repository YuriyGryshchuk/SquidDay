using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    private InputButtonData _inputButtonData;
    private PlayerConfig _playerConfig;
    private Vector2 _currentVector;
    private float _currentSpeed;
    private float _currentTime;
    private Animator _squidAnimator;
    private bool _isPressedPush;

    [Inject]
    private void Conctruct(InputButtonData inputButtonData, PlayerConfig playerConfig)
    {
        _playerConfig = playerConfig;
        _inputButtonData = inputButtonData;
    }

    private void Start()
    {
        _squidAnimator = GetComponent<Animator>();
        _currentTime = 0;
        CreateAllEventTrigger();
    }

    private void CreateAllEventTrigger()
    {
        CreateNewEventTriger(_inputButtonData.PushButton, EventTriggerType.PointerDown,
            (data) => { OnDawnPush((PointerEventData)data); });
        CreateNewEventTriger(_inputButtonData.PushButton, EventTriggerType.PointerUp,
            (data) => { OnUpPush((PointerEventData)data); });
    }

    private void CreateNewEventTriger(Button button, EventTriggerType eventTriggerType, UnityAction<BaseEventData> metod)
    {
        EventTrigger trigger = button.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        entry.callback.AddListener(metod);
        trigger.triggers.Add(entry);
    }

    private void Update()
    {
        Timer();
        PushPlayer();
        MovePlayer();
    }

    private void LimitPosition()
    {
        RectangleBounds bounds = Camera.main.GetComponent<CameraBounds>().RectBounds;
        var v3 = transform.position;
        if (transform.position.x < bounds.minX || transform.position.x > bounds.maxX 
            || transform.position.y < bounds.minY || transform.position.y > bounds.maxY)
        {
            v3.x = Mathf.Clamp(v3.x, bounds.minX, bounds.maxX);
            v3.y = Mathf.Clamp(v3.y, bounds.minY, bounds.maxY);
            v3 *= -1;
            transform.position = v3;
        }
    }
    private void PushPlayer()
    {
        if (_currentTime >= _playerConfig.TimeWithoutMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) || _isPressedPush)
            {
                SetPushStats();
            }
        }
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(_currentVector * _currentSpeed * Time.deltaTime, Space.World);
        LimitPosition();
        _currentSpeed -= _playerConfig.SlowdownVelosity;
        if (_currentSpeed <= 0)
            _currentSpeed = 0;
    }

    private void SetPushStats()
    {
        _currentVector = transform.up;
        _currentSpeed = _playerConfig.PlayerPushForce;
        Instantiate(_playerConfig.PlayerProjectile, transform.position, transform.localRotation);
        _squidAnimator.SetTrigger("Forse");
        _currentTime = 0;
    }

    private void Timer()
    {
        _currentTime += Time.deltaTime;
    }

    private void OnDawnPush(PointerEventData data)
    {
        _isPressedPush = true;
    }

    private void OnUpPush(PointerEventData data)
    {
        _isPressedPush = false;
    }
}
