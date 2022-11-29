using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public void playgame()
    {///check File -> building setting then put scence after this scence will load next scence
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Endgame()
    {
        Application.Quit();
    }
}
