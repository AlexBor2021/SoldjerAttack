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
    [SerializeField] private AudioSource _music;

    private int _enemyKillCount;
    private BarGold _barGold;

    private void OnEnable()
    {
        _music.Stop();

        _barGold = BarGold.Instance;

        RevardForLevel(false);

        DataGame.InfoLevel.SaveInfoLevel(SceneManager.GetActiveScene().buildIndex+1);
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

    public void RevardForLevel(bool marketing)
    {
        _barGold.TakeGold(_revardForLevel);

        if (marketing)
        {
            _moneyText.text = (_revardForLevel*2).ToString();
        }
        else
        {
            _moneyText.text = _revardForLevel.ToString();
        }
    }
}
