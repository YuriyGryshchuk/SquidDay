using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class PlayerRotate : MonoBehaviour
{
    private InputButtonData _inputButtonData;
    private PlayerConfig _playerConfig;
    private bool _isPressedLeft;
    private bool _isPressedRight;

    [Inject]
    private void Conctruct(InputButtonData inputButtonData, PlayerConfig playerConfig)
    {
        _playerConfig = playerConfig;
        _inputButtonData = inputButtonData;
    }

    void Start()
    {
        CreateAllEventTrigger();
    }

    private void CreateAllEventTrigger()
    {
        CreateNewEventTriger(_inputButtonData.LeftRotationButton, EventTriggerType.PointerDown,
            (data) => { OnDawnLeft((PointerEventData)data); });
        CreateNewEventTriger(_inputButtonData.LeftRotationButton, EventTriggerType.PointerUp,
           (data) => { OnUpLeft((PointerEventData)data); });
        CreateNewEventTriger(_inputButtonData.RightRotationButton, EventTriggerType.PointerDown,
           (data) => { OnDawnRight((PointerEventData)data); });
        CreateNewEventTriger(_inputButtonData.RightRotationButton, EventTriggerType.PointerUp,
           (data) => { OnUpRight((PointerEventData)data); });
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
        float rotation = Input.GetAxis("Horizontal") * _playerConfig.SpeedToRotatePlayer;

        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);

        if (_isPressedLeft)
            Rotate(-1);

        if (_isPressedRight)
            Rotate(1);
    }

    private void Rotate(float direction)
    {
        float rotation = direction * _playerConfig.SpeedToRotatePlayer;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);
    }
    
    private void OnDawnLeft(PointerEventData data)
    {
        _isPressedLeft = true;
    }

    private void OnUpLeft(PointerEventData data)
    {
        _isPressedLeft = false;
    }

    private void OnDawnRight(PointerEventData data)
    {
        _isPressedRight = true;
    }

    private void OnUpRight(PointerEventData data)
    {
            _isPressedRight = false;
    }
}
