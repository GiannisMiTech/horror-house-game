using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void OnPlayButton()
  {
    SceneManager.LoadScene(1);
   
  }

  public void OnQuitButton()
  {
    Application.Quit();
  }
}
