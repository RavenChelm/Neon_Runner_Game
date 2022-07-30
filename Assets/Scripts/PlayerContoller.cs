using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerContoller : MonoBehaviour
{

    //Передвижение
    public CharacterController _controller;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private GameObject Capsule;
    private GameObject PlModel;

    //Пауза 
    private bool Game = false;
    private bool Dead = false;
    public bool jump = false;
    public bool slide = false;
    public bool Time_swich = true;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject EndGameMenu;

    //Очки
    [SerializeField] public GameObject score;
    public Score _score;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _score = score.GetComponent<Score>();
        Capsule = gameObject.transform.GetChild(1).gameObject;
        PlModel = gameObject.transform.GetChild(0).gameObject;
    }
    void Awake()
    {
        Debug.Log(Game);
    }

    void Update()
    {
        if (Game == true && Dead == false)
        {
            if (_controller.isGrounded)
            {
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    jump = true;
                }
                jump = false;

            }
            else
            {
                if (Input.GetButton("Jump"))
                {
                    jump = true;
                }
                else
                {
                    jump = false;
                }
                moveDirection.y -= gravity * Time.deltaTime;
            }
            _controller.Move(moveDirection * Time.deltaTime);
            if (Input.GetAxis("Vertical") < 0 && _controller.isGrounded)
            {
                slide = true;
                _controller.height = 0.85f;
                var Yscale = Capsule.transform.localScale;
                Yscale.y = 0.5f;
                Capsule.transform.localScale = Yscale;

                var YPosition = Capsule.transform.localPosition;
                YPosition.y = -0.5f;
                Capsule.transform.localPosition = YPosition;

                var plTransf = PlModel.transform.localPosition;
                plTransf.y = -0.5f;
                PlModel.transform.localPosition = plTransf;
            }
            else if (_controller.isGrounded)
            {
                slide = false;
                _controller.height = 1.9f;
                var Yscale = Capsule.transform.localScale;
                Yscale.y = 1;
                Capsule.transform.localScale = Yscale;

                var YPosition = Capsule.transform.localPosition;
                YPosition.y = 0;
                Capsule.transform.localPosition = YPosition;

                var plTransf = PlModel.transform.localPosition;
                plTransf.y = -1.01f;
                PlModel.transform.localPosition = plTransf;
            }
        }
        else if (Dead == true)
        {
            Time.timeScale = 0;
            EndGameMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Dead == false && Time_swich == false)
        {
            PauseGame();

        }

    }
    public void PauseGame()
    {
        Debug.Log(Game);

        Game = !Game;
        if (Game == true && Dead == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public bool GetGameStatus()
    {
        return Game;
    }
    public void SetGameStatus(bool status)
    {
        Game = status;
    }
    public bool GetDeadStatus()
    {
        return Dead;
    }
    public void SetDeadStatus(bool status)
    {
        Dead = status;
    }
}
