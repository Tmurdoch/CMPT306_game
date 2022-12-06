using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] public IntSO coinsSO;
    [SerializeField] public IntSO scoreSO;

    [SerializeField] public Text scoreText;

    void Awake() {
        scoreText.text = "Final Score: " + scoreSO.Value;
    }

    public void playAgain()
    {
        scoreSO.Value = 0;
        coinsSO.Value = 0;
        
        ///check File -> building setting then put scene after this scene will load next scence
        SceneManager.LoadScene(1);
    }
    public void quit()
    {
        Application.Quit();
    }
}
