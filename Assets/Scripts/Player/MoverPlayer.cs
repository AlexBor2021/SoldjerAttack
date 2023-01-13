using UnityEngine;
//using Agava.YandexGames;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigiBody;
    [SerializeField] private Animation _animation;
    [SerializeField] private KeyBoordInput _keyBoordInput;
    [SerializeField] private VariableJoystick _variableJoystick;

    private Vector3 _directionMove;
    private bool _setKeyboard;

    private void Awake()
    {
#if UNITY_EDITOR
        _keyBoordInput.Init(this);
#elif UNITY_WEBGL && YANDEX_GAMES
        _setKeyboard = FindObjectOfType<SDKIntialize>().InputSystemKeyBoard;
        if (_setKeyboard)
        {
            _keyBoordInput.Init(this);
        }
        else
        {
            _variableJoystick.gameObject.SetActive(true);
            _variableJoystick.Init(this);
        }
#endif
    }

    public void FixedUpdate()
    {
        _rigiBody.velocity = _directionMove * _speed;

        if (_directionMove != Vector3.zero)
        {
            var vector = Vector3.RotateTowards(transform.forward, _rigiBody.velocity, 6f * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(vector);
            _animation.SetMove(true);
        }
        else
        {
            _animation.SetMove(false);
        }
    }

    public void SetDiractionMove(Vector3 diraction)
    {
        _directionMove = diraction;
    }

}