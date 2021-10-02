using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Button goButton;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = goButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Time.timeScale = 1;

    }

    void OnClick()
    {
        ChangeScene(sceneName);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
