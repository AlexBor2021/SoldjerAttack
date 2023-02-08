using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _enemyKill;
    [SerializeField] private TextMeshProUGUI _vicalsKill;
    [SerializeField] private GameObject _vicalsIcon;
    [SerializeField] private int _revardForLevel;

    private int _enemyKillCount;
    private BarGold _barGold;

    private void OnEnable()
    {
        _barGold = FindObjectOfType<BarGold>();
        _barGold.TakeGold(_revardForLevel);
        RevardForLevel();
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void SetEnemyKills()
    {
        _enemyKillCount++;
        _enemyKill.text = _enemyKillCount.ToString();
    }
    private void RevardForLevel()
    {
        _moneyText.text = _revardForLevel.ToString();
    }
}
