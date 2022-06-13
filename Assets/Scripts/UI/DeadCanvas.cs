using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class DeadCanvas : MonoBehaviour
{
    [SerializeField] private Squid _squid;
    [SerializeField] private Canvas _deadCanvas;
    [SerializeField] private Canvas _revivalCanvas;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private RestartSystem _restartSystem;
    [SerializeField] private Image _revivalTimer;
    [SerializeField] private Button _deadButton;
    [SerializeField] private Button _saveButton;
    [SerializeField] private RevivalAds _rewardedAds;


    private float _revivalTime = 1f;
    private bool _isRevival;
    private bool _isRevivaled = false;

    private void Start()
    {
        _squid.Die += Dead;
        _isRevival = false;
        DiableAllDeadCanvas();
        _restartSystem.onRevival.AddListener(DiableAllDeadCanvas);
    }
    private void Update()
    {
        if (_isRevival)
        {
            _revivalTime -= Time.deltaTime * 0.2f;
            _revivalTimer.fillAmount = _revivalTime;
            if (_revivalTime <= 0)
            {
                _revivalTime = 1f;
                NotRevival();
                _isRevival = false;
            }
        }
       
    }
    private void Dead(int score, int coins)
    {
        if (!_isRevivaled)
        {
            _revivalCanvas.enabled = true;
            _isRevival = true;
        }
        else
        {
            NotRevival();
        }


        
       
        _score.text = score.ToString();
        _coins.text = coins.ToString();
    
    }

    public void Restart()
    {
      

        _restartSystem.Restart();
        _isRevivaled = false;
        Time.timeScale = 1;
        _deadCanvas.enabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Revival()
    {
        _isRevival = false;
        _revivalTime = 1f;
        _rewardedAds.AdsShow();
        _isRevivaled = true;
    }
    private void DiableAllDeadCanvas()
    {
        _revivalCanvas.enabled = false;
        _deadCanvas.enabled = false;
    }
    public void NotRevival()
    {
        Time.timeScale = 0;
        _isRevival = false;
        _revivalCanvas.enabled = false;
        _deadCanvas.enabled = true;
    }
}
