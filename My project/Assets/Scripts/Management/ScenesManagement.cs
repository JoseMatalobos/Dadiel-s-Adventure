using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManagement : MonoBehaviour
{
    public GameObject askClosePanel;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        askClosePanel.SetActive(false);
    }

    public void LoadScene(string nextScene) 
    {
        SceneManager.LoadScene(nextScene);
    }

    public void CloseProgram() 
    {
        Application.Quit();
        Debug.Log("Has cerrado el juego.");
    }

    public void OpenClosePanel() 
    {
        askClosePanel.SetActive(true);
        Debug.Log("Has abierto el panel.");
    }
    public void CloseAskPanel() 
    {
        askClosePanel.SetActive(false);
        Debug.Log("Has cerrado el panel.");
    }
}
