using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private int Lives = 3;
    public Text LivesText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = Lives.ToString();
    }

    public void DecrementLives()
    {
        Lives--;
    }

    public int GetLives()
    {
        return Lives;
    }
}
