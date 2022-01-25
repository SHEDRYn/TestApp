using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public int maxMessage = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    [SerializeField]
    List<Message> messagesList = new List<Message>();


    public void PressSendButton()
    {
        SendMessageToChat("-Вы: " + chatBox.text);
        chatBox.text = "";
    }


    public void SendMessageToChat(string text)
    {
        if (messagesList.Count >= maxMessage)
        {
            Destroy(messagesList[0].textObject.gameObject);
            messagesList.Remove(messagesList[0]);
        }

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messagesList.Add(newMessage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
