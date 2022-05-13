using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class LoginMain : MonoBehaviour
{
  [SerializeField]  InputField _emailRegister, _passwordRegister, _usernameRegister, _repeatPasswordRegister;
    [SerializeField] InputField  _passwordLogin, _usernameandEmailLogin;
    [SerializeField] Toggle _rememberToggle;
    [Header("Guest Login Settings")]
    [SerializeField] bool _GuestLogin;
    [SerializeField] Button _LoginOrRegisterButton;
    [SerializeField] Text _registerOrloginText,_alreadyText;
    [SerializeField] GameObject _emailRegisterGO, _passwordRegisterGo, _usernameRegisterGo, _repeatPasswordRegisterGo, _passwordLoginGo, _usernameandEmailLoginGo, _rememberToggleGo;

    #region RegisterLogin System
    public void LoginEmail()
    {
        //PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest() { Email = _usernameandEmailLogin.text, Password = _passwordLogin.text }, Result => { Debug.Log("Giris Basarili"); }, Error =>
        //{
        //    Debug.Log("Giris Basarisiz");
        //});
        Debug.Log("aaa");
            }

    private void Awake()
    {
        SwitchLoginorRegister();
    }
    public void LoginUsername()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() { Username = _usernameRegister.text,Password=_passwordLogin.text }, Result => { Debug.Log("Giris Basarili"); }, Error =>
        {
            Debug.Log("Giris Basarisiz");
        });

        } 
      public void SwitchLoginType()
    {
        if (_usernameandEmailLogin.text.IndexOf('@')>0)
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
        //PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest() { Username=_usernameRegister.text,Email=_emailRegister.text,Password=_passwordRegister.text }, Result => { Debug.Log("Giris Basarili"); }, Error =>
        //{
        //    Debug.Log("Giris Basarisiz");
        //});
        Debug.Log("bbb");
    }
    public void RememberMe()
    {
        if (_rememberToggle.isOn)
        {
            PlayerPrefs.SetString("emailOrUsername", _usernameandEmailLogin.text);
            PlayerPrefs.SetString("password", _passwordLogin.text);
        }
    } 
    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() { CreateAccount= _GuestLogin,}, Result => { }, Error => { });
    }
    #endregion
    public void SwitchLoginorRegister()
    {
        switch (_emailRegisterGO.activeInHierarchy)
        {
            case false:
                _usernameandEmailLoginGo.SetActive(false);
                _passwordLoginGo.SetActive(false);
                _emailRegisterGO.SetActive(true);
                _passwordRegisterGo.SetActive(true);
                _repeatPasswordRegisterGo.SetActive(true);
                _usernameRegisterGo.SetActive(true);
                _registerOrloginText.text = "Register";
                _alreadyText.text = "Login";
                _rememberToggleGo.SetActive(false);
                _LoginOrRegisterButton.onClick.AddListener(SwitchLoginType);
                _LoginOrRegisterButton.onClick.AddListener(Register);

                break;
            default:
                _usernameandEmailLoginGo.SetActive(true);
                _passwordLoginGo.SetActive(true);
                _emailRegisterGO.SetActive(false);
                _passwordRegisterGo.SetActive(false);
                _repeatPasswordRegisterGo.SetActive(false);
                _usernameRegisterGo.SetActive(false);
                _registerOrloginText.text = "Login";
                _alreadyText.text = "Register";
                _LoginOrRegisterButton.onClick.AddListener(Register);
                _LoginOrRegisterButton.onClick.AddListener(SwitchLoginType);
                break;
        }
       
    }
}
