using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class LoginMain : MonoBehaviour
{

    [SerializeField]
    InputField _emailRegister, _passwordRegister, _usernameRegister, _repeatPasswordRegister;
    [SerializeField]
    InputField _passwordLogin, _usernameAndEmailLogin;
    [SerializeField]
    Button _RegisterButton, _LoginButton;
    [SerializeField]
    Text _resultText;
    [Header("Guest Login Settings")]
    [SerializeField]
    bool _guestLogin;
    [SerializeField]
    GameObject _registerPanel, _loginPanel;
    [SerializeField] Animator _animator;


    private void Start()
    {
        SwitchLoginOrRegister();
    }

    #region RegisterLogin System

    public void LoginEmail()
    {
        
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest()
        {
            Email = _usernameAndEmailLogin.text,
            Password = _passwordLogin.text

        },
        Result =>
        {
            Debug.Log("Giris basarili");

        },
        Error =>
        {
            Debug.Log("Giris Basarisiz");

        });
        Debug.Log("aaaaa");
    }


    public void LoginUsername()
    {
        
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
        {
            Username = _usernameAndEmailLogin.text,
            Password = _passwordLogin.text

        },
        Result =>
        {
            Debug.Log("Giris basarili");

        },
        Error =>
        {
            Debug.Log("Giris Basarisiz");

        }); ;
    }

    public void SwitchLoginType()
    {
        if (_usernameAndEmailLogin.text.IndexOf('@') > 0)
        {
            LoginEmail();
        }
        else
        {
            LoginUsername();
        }
    }


    public void Register()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            Username = _usernameRegister.text,
            Email = _emailRegister.text,
            Password = _passwordRegister.text

        },
        Result =>
        {
            _animator.Play("Success");
            Debug.Log("Kayit basarili");

        },
        Error =>
        {
            Debug.Log("Kayit Basarisiz");
            _animator.Play("Fail");
        }); 
        Debug.Log("bbbbb");

    }

    public void RememberMe()
    {



        PlayerPrefs.SetString("emailOrUsername", _usernameAndEmailLogin.text);
        PlayerPrefs.SetString("passoword", _passwordLogin.text);


        //PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        //{


        //},
        //Result =>
        //{

        //},
        //Error =>
        //{

        //});
    }



    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = _guestLogin,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier


        },
        Result =>
        {
            Debug.Log("Misafir Girisi basarili");
        },
        Error =>
        {
            Debug.Log("Misafir Girisi basarisiz");
        });
    }

    public void SwitchLoginOrRegister()
    {
        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;
            default:
                _loginPanel.SetActive(false);
                _registerPanel.SetActive(true);
                break;
        }
    }


    #endregion


}
