using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTextCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberLevel;

    private void OnEnable()
    {
        _numberLevel.text = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
    }
}
