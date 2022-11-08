using UnityEngine;
using UnityEngine.UI;

public class InputButtonData : MonoBehaviour
{
    [SerializeField]
    private Button _leftRotationButton;
    [SerializeField]
    private Button _rightRotationButton;
    [SerializeField]
    private Button _pushButton;

    public Button LeftRotationButton => _leftRotationButton;
    public Button RightRotationButton => _rightRotationButton;
    public Button PushButton => _pushButton;
}
