using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Steph
{
    public class SceneControl : MonoBehaviour
    {
        #region Variables
        [Header("Scene Control Variables")]
        public static bool gameScene, muted;
        public bool paused;
        public GameObject mainPanel, optionsPanel;
        #endregion

        void Update()
        {
            if (gameScene) //if in game
            {
                #region press space to pause game
                if (Input.GetKeyDown(KeyCode.Space)) //if press space bar
                {
                    if (optionsPanel.activeSelf) //if the options panel is active
                    {
                        //consider turning into a function if we need to save options
                        optionsPanel.SetActive(false); //turn off the options panel
                        mainPanel.SetActive(true); //turn on the pause panel
                    }
                    else
                    {
                        paused = !paused; //switches pause on/off
                        if (paused)
                        {
                            Pause();
                        }
                        else
                        {
                            Resume();
                        }
                    }
                }
                #endregion
            }
        }
        #region Functions
        #region Quit
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //exits play mode in unity
#endif
            Application.Quit(); //exits app when built
        }
        #endregion
        #region Pause
        public void Pause()
        {
            paused = true; //sets bool value
            Time.timeScale = 0; //pauses time
            mainPanel.SetActive(true); //turns on pause panel in game scene
        }
        #endregion
        #region Resume
        public void Resume()
        {
            paused = false; //sets bool value
            Time.timeScale = 1; //resumes time
            mainPanel.SetActive(true); //turns off pause panel in game scene
        }
        #endregion
        #region ChangeScene
        public void ChangeScene(int index)
        {
            if (index == 1) //if moving to scene 1
            {
                gameScene = true; //we are in the game scene
                Resume(); //resume game so we don't start paused
            }
            SceneManager.LoadScene(index); //loads scene with given index
        }
        #endregion
        #endregion
    }
}