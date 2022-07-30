using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuContoller : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    private PlayerContoller _playerCnt;
    [SerializeField] private GameObject _inputF;
    private TMP_InputField inputField;
    [SerializeField] private GameObject recordField;
    [SerializeField] private GameObject textRecPref;
    private Game gms = new Game();
    [SerializeField] private bool MainMenu;
    private void Start()
    {
        _playerCnt = _playerObj.GetComponent<PlayerContoller>();
    }
    private void Awake()
    {
        LoadGame();
    }

    //main menu
    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }


    //pause menu
    public void ToMainMenu()
    {
        _playerCnt.SetDeadStatus(false);
        _playerCnt.SetGameStatus(true);
        _playerCnt._score.setToDefault();
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void BacktoGame()
    {
        _playerCnt.PauseGame();
    }

    //endGame
    public void PlayPressedAgain()
    {
        _playerCnt.SetDeadStatus(false);
        _playerCnt.SetGameStatus(true);
        _playerCnt._score.setToDefault();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void enterName()
    {
        inputField = _inputF.GetComponent<TMP_InputField>();
        Game.current.InputVarieble(inputField.text, (int)_playerCnt._score.timeStart);
    }
    public void SaveGame()
    {
        SaveLoadRecodrs.SaveRecodrs();
    }
    //records Menu
    public void LoadGame()
    {
        if (MainMenu == true)
        {
            SaveLoadRecodrs.LoadRecodrs();
            if (recordField.transform.childCount > 0)
            {
                for (int j = recordField.transform.childCount; j > 0; --j)
                    Destroy(recordField.transform.GetChild(0).gameObject);
            }

            foreach (Game gm in SaveLoadRecodrs.savedGames)
            {
                var textOBj = Instantiate(textRecPref, recordField.transform);
                var text = textOBj.GetComponent<TMP_Text>();
                text.SetText(" Name: " + gm.playerName + " , " + "Score: " + gm.scoreField);
                Debug.Log(gm.playerName + ": " + gm.scoreField);
            }
        }

    }


}
