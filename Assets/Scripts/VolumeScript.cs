using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VolumeScript : MonoBehaviour {

    private void Start()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        Slider volSlider = GameObject.Find("VolSlider").GetComponent<Slider>();
        volSlider.value = float.Parse(xScript.allData[xScript.choice, 25]);
    }
    void Update () {
        float volSlider = GameObject.Find("VolSlider").GetComponent<Slider>().value;
        if (volSlider <= 100 && volSlider >= 67) { GetComponent<Image>().sprite = Resources.Load<Sprite>("Volume3"); }
        else if (volSlider <= 66 && volSlider >= 33) { GetComponent<Image>().sprite = Resources.Load<Sprite>("Volume2"); }
        else if (volSlider <= 32 && volSlider >= 1) { GetComponent<Image>().sprite = Resources.Load<Sprite>("Volume1"); }
        else { GetComponent<Image>().sprite = Resources.Load<Sprite>("Volume0"); }
        GameObject.Find("ButtonManager").GetComponent<ButtonScript>().num2 = volSlider.ToString();
    }
    public void onClick()
    {
        Slider volSlider = GameObject.Find("VolSlider").GetComponent<Slider>();
        if (volSlider.value>0)
        {
            volSlider.value = 0f;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Volume0");
        }
        else
        {
            volSlider.value = 60f;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Volume2");
        }
    }
    public void Volume()
    {
        GameObject.Find("MusicObject").GetComponent<AudioSource>().volume = GameObject.Find("VolSlider").GetComponent<Slider>().value * 0.01f;
    }
    public void VolumeReset()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        GameObject.Find("MusicObject").GetComponent<AudioSource>().volume = float.Parse(xScript.allData[xScript.choice, 25]);
        SceneManager.LoadScene("Main Menu");
    }
}