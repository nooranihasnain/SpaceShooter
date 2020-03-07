using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text ScoreText;
    private ScoreManager SCM;
    // Start is called before the first frame update
    void Start()
    {
        SCM = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        ScoreText.text = "Score: " + SCM.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
