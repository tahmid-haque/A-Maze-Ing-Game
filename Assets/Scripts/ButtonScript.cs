using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ButtonScript : MonoBehaviour
{
    public string num1, num2;
    private string[,] temp=new string[101,26];
    private string xName, password;
    private int i;
    private GameObject userNameData, passwordData;
    private void Start()
    {
        userNameData = GameObject.Find("UserNameData");
        passwordData = GameObject.Find("PasswordData");
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        num1 = xScript.allData[xScript.choice, 3];
        num2 = xScript.allData[xScript.choice, 25];
    }
    public void buttonManager(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void characterSwap(int character)
    {
        num1 = character.ToString();
    }
    public void AcceptSettings()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        xScript.allData[xScript.choice, 3] = num1;
        xScript.allData[xScript.choice, 25] = num2;
        xScript.writeFile();
        SceneManager.LoadScene("Main Menu");
    }
    public void Login()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        xName = userNameData.GetComponent<InputField>().text.ToString();
        password = passwordData.GetComponent<InputField>().text.ToString();

        for (int y = 0; y <= xScript.size; y++)
        {
            if (xName == xScript.allData[y, 0])
            {
                if (password == xScript.allData[y, 1])
                {
                    xScript.choice = y;
                    GameObject.Find("MusicObject").GetComponent<AudioSource>().volume = float.Parse(xScript.allData[xScript.choice, 25]) * 0.01f;
                    SceneManager.LoadScene("Main Menu");
                    return;
                }
                else
                {
                    GameObject.Find("ErrorBox").GetComponent<Text>().text = "ERROR: Password is INCORRECT!(All inputs are case-sensitive.)";
                    passwordData.GetComponent<InputField>().text = "";
                    return;
                }
            }
        }
        GameObject.Find("ErrorBox").GetComponent<Text>().text = "ERROR: User not Found! (All inputs are case-sensitive.)";
        userNameData.GetComponent<InputField>().text = "";
        passwordData.GetComponent<InputField>().text = "";

    }
    public void CreateProfile()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();

        xName = userNameData.GetComponent<InputField>().text.ToString();
        password = passwordData.GetComponent<InputField>().text.ToString();
        if (xName.Length <= 4)
        {
            GameObject.Find("ErrorBox").GetComponent<Text>().text = "ERROR: Enter a name between 5-20 characters!";
            userNameData.GetComponent<InputField>().text = "";
            passwordData.GetComponent<InputField>().text = "";
            return;
        }
        else if (password.Length <= 4)
        {
            GameObject.Find("ErrorBox").GetComponent<Text>().text = "ERROR: Enter a password between 5 - 20 characters!";
            passwordData.GetComponent<InputField>().text = "";
            return;
        }
        for (int g = 0; g <= xScript.size; g++)
        {
            if (xName == xScript.allData[g, 0])
            {
                GameObject.Find("ErrorBox").GetComponent<Text>().text = "ERROR: "+xName + " is already taken!";
                userNameData.GetComponent<InputField>().text = "";
                passwordData.GetComponent<InputField>().text = "";
                return;
            }
        }
        xScript.choice = xScript.size;
        xScript.size += 1;
        for (int s = 0; s < 26; s++)
        {
            xScript.allData[xScript.choice, s] = "0";
        }
        xScript.allData[xScript.choice, 0] = xName;
        xScript.allData[xScript.choice, 1] = password;
        xScript.allData[xScript.choice, 2] = "1";
        xScript.allData[xScript.choice, 3] = "1";
        xScript.allData[xScript.choice, 25] = "60";
        SceneManager.LoadScene("Customization Screen");
    }
    public void PlayGame()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        switch (xScript.allData[xScript.choice, 2])
        {
            case "1":
                SceneManager.LoadScene("Level 1");
                break;
            case "2":
                SceneManager.LoadScene("Level 2");
                break;
            case "3":
                SceneManager.LoadScene("Level 3");
                break;
            case "4":
                SceneManager.LoadScene("Level 4");
                break;
            case "5":
                SceneManager.LoadScene("Level 5");
                break;
            case "6":
                SceneManager.LoadScene("Final Level");
                break;
        }
    }
    public void Delete()
    {
                    xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
                    for ( i= 0; i < xScript.size; i++)
                    {
                        if (i != xScript.choice)
                        {
                            for (int k = 0; k < 26; k++)
                            {
                                temp[i, k] = xScript.allData[i, k];
                            }
                        }
                        else { break; }
                    }
                    for (int x = (i+1); x < xScript.size; x++)
                    {
                        for (int v = 0; v < 26; v++)
                        {
                            Debug.Log("i="+i);
                            Debug.Log("x-1=" + (x-1));
                            temp[x-1, v] = xScript.allData[x, v];
                        }
                    }
                    xScript.allData = temp;
                    xScript.choice = -1;
                    xScript.size -= 1;
                    xScript.writeFile();
                    SceneManager.LoadScene("Profile");
                }
	public void Exit()
	{
		Application.Quit();
    }
}