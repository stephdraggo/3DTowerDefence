using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Steph
{
    public class OptionsMenu : SceneControl
    {
        #region Variables
        [Header("Options Menu Variables")]
        public Dropdown resolutionSelect;
        public Resolution[] resolutionList;
        public AudioMixer audioControl;
        public AudioSource music, click;
        #endregion
        void Start()
        {
            StartRes(); //set up the resolution dropdown
            optionsPanel.SetActive(false); //make sure the options panel is off
        }
        #region Functions
        #region MuteToggle
        public void MuteToggle(bool mute)
        {
            if (mute)
            {
                audioControl.SetFloat("volume", -80);
            }
            else
            {
                audioControl.SetFloat("volume", 0);
            }
        }
        #endregion
        #region StartRes
        public void StartRes()
        {
            resolutionList = Screen.resolutions; //sets the array to contain the resolutions for the current display
            resolutionSelect.ClearOptions(); //empties the previous selection list
            List<string> choices = new List<string>(); //creates empty list for resolution options
            int index = 0;
            for (int i = 0; i < resolutionList.Length; i++) //for every resolution available on this display
            {
                string option = resolutionList[i].width + " x " + resolutionList[i].height; //displays the resolutions as strings
                choices.Add(option); //adds the string to the list of resolution options
                if (resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height) //if the current screen resolution is selected
                {
                    index = i; //the current resolution is selected
                }
            }
            resolutionSelect.AddOptions(choices); //puts the options into the dropdown menu
            resolutionSelect.value = index; //this is the index of the resolution option that was chosen
            resolutionSelect.RefreshShownValue(); //not entirely sure what this does but I think it goes here
        }
        #endregion
        #region SetResolution
        public void SetResolution(int index)
        {
            Resolution res = resolutionList[index]; //makes the next line easier to read
            Screen.SetResolution(res.width, res.height, Screen.fullScreen); //sets the resolution to what the player chose, and fullscreen?
        }
        #endregion
        #region SetFullscreen
        public void SetFullscreen(bool full)
        {
            Screen.fullScreen = full; //assigns the bool value
        }
        #endregion
        #region SetVolume
        public void SetVolume(float volume)
        {
            audioControl.SetFloat("volume", volume);
        }
        #endregion
        #region SetGraphics
        public void SetGraphics(int index)
        {
            QualitySettings.SetQualityLevel(index); //sets the graphics quality according to the built-in options in the game
        }
        #endregion
        #region Click
        public void Click()
        {
            click.Play(); //plays the click sound
        }
        #endregion
        #endregion
    }
}