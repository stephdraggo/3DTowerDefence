using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    #region Variables
    [Header("Scene Control Variables")]
    public bool muted;
    public bool paused;
    public GameObject mainPanel, optionsPanel;
    #endregion
    void Start()
    {
        optionsPanel.SetActive(false); //disable options panel to start with
    }

    void Update()
    {
        
    }
    #region Functions
    #region Quit
    public void Quit()
    {

    }
    #endregion
    #region Pause
    public void Pause()
    {

    }
    #endregion
    #region Resume
    public void Resume()
    {

    }
    #endregion
    #region ChangeScene
    public void ChangeScene(int index)
    {

    }
    #endregion
    #endregion
}
