using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    [SerializeField] Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
 
    void LoadScene()
    {
        SceneManager.LoadScene("MyGame");
    }

}
