using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public Button startButton;
    public Button messageButton;
    public Label messageText;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("Start_Game");
        messageButton = root.Q<Button>("Show_Message");
        messageText = root.Q<Label>("Message_Text");

        startButton.clicked += StartButtonPressed;
        messageButton.clicked += MessageButtonPressed;
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("game");
    }
    void MessageButtonPressed()
    {
        messageText.text = "subscribe to Alan";
        messageText.style.display = DisplayStyle.Flex;
 
    }
}
