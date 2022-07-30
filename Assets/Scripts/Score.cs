using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerContoller _playerCnt;
    public TMP_Text scoreStr;
    [SerializeField] private GameObject Timeobj;

    public TMP_Text TimeText;
    [SerializeField] private bool endGame = false;
    public float timeStart = -3;
    public bool oneForAll = true;
    private void Start()
    {
        scoreStr = gameObject.GetComponent<TMP_Text>();
    }
    private void Awake()
    {
        TimeText = Timeobj.GetComponent<TMP_Text>();

    }
    private void Update()
    {
        if (_playerCnt.GetGameStatus() == true)
        {
            timeStart += Time.deltaTime;
            if (timeStart > 0)
            {
                scoreStr.SetText("Scrore: " + timeStart.ToString("F0"));
            }
        }
        else
        {
            Debug.Log(2);
            timeStart += Time.deltaTime;
            if (timeStart >= 0 && oneForAll == true)
            {
                _playerCnt.Time_swich = false;
                _playerCnt.SetGameStatus(true);
                TimeText.gameObject.SetActive(false);
                oneForAll = false;
            }
            else
            {
                TimeText.SetText((-1 * timeStart).ToString("F0"));
            }
        }
    }
    public void setToDefault()
    {
        timeStart = -3;
    }
    public void setScore(string scr)
    {
        scoreStr.SetText(scr);
    }
}
