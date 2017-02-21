using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button loginBtn;
    public Button registerBtn;
    public Button loginCloseBtn;
    public Button registerCloseBtn;
    public Button confirmBtn_Login;
    public Button confirmBtn_Register;
    public Button cancelBtn_Login;
    public Button cancelBtn_Register;
    public InputField accountInput_Login;
    public InputField passwordInput_Login;
    public InputField accountInput_Register;
    public InputField passwordInput_Register;
    public InputField password2Input_Register;
    public GameObject loginPanel;
    public GameObject registerPanel;

    void Awake()
    {
        loginBtn.onClick.AddListener(delegate { OnLoginBtnClick(); });
        registerBtn.onClick.AddListener(delegate { OnRegisterBtnClick(); });
        loginCloseBtn.onClick.AddListener(delegate { OnLoginCloseBtnClick(); });
        registerCloseBtn.onClick.AddListener(delegate { OnRegisterCloseBtnClick(); });
        confirmBtn_Login.onClick.AddListener(delegate { OnLoginConfirmBtnClick(); });
        confirmBtn_Register.onClick.AddListener(delegate { OnRegisterConfirmBtnClick(); });
        cancelBtn_Login.onClick.AddListener(delegate { OnLoginCancelBtnClick(); });
        cancelBtn_Register.onClick.AddListener(delegate { OnRegisterCancelBtnClick(); });
    }

    void OnLoginBtnClick()
    {
        loginPanel.SetActive(true);
    }

    void OnRegisterBtnClick()
    {
        registerPanel.SetActive(true);
    }

    void OnLoginCloseBtnClick()
    {
        ClearInfo();
        loginPanel.SetActive(false);
    }

    void OnRegisterCloseBtnClick()
    {
        ClearInfo();
        registerPanel.SetActive(false);
    }

    void OnLoginConfirmBtnClick()
    {
        string account = accountInput_Login.text;
        string password = passwordInput_Login.text;
        if (account.Length < 3 || account.Length > 10
            || password.Length < 3 || password.Length > 10)
        {
            Debug.Log("账号密码不合法!!!");
        }
        else
        {
            // ----------登录请求----------
            SendManager.Instance.SendMsg_Login(account, password);
        }
        ClearInfo();
    }

    void OnRegisterConfirmBtnClick()
    {
        string account = accountInput_Register.text;
        string password = passwordInput_Register.text;
        string password2 = passwordInput_Register.text;
        if (account.Length < 3 || account.Length > 10
            || password.Length < 3 || password.Length > 10
            || password2.Length < 3 || password2.Length > 10)
        {
            Debug.Log("账号密码不合法!!!");
        }
        else
        {
            // ----------注册请求----------
            SendManager.Instance.SendMsg_Register(account, password);
        }
        ClearInfo();
    }

    void OnLoginCancelBtnClick()
    {
        ClearInfo();
        loginPanel.SetActive(false);
    }

    void OnRegisterCancelBtnClick()
    {
        ClearInfo();
        registerPanel.SetActive(false);
    }

    void ClearInfo()
    {
        accountInput_Login.text = "";
        passwordInput_Login.text = "";
        accountInput_Register.text = "";
        passwordInput_Register.text = "";
        password2Input_Register.text = "";
    }
}
