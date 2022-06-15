using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
