using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OpenAI {
public class ChatBotManager : MonoBehaviour
{
    public GameObject responseDisplay;

    public TextMeshProUGUI responseDisplayText;
    public GameObject inputTextBox;

    public TextMeshProUGUI inputText;

    //api key
    public static string openAIAPIKey = "";

    //create openai object
    private OpenAIApi openai = new OpenAIApi(openAIAPIKey);

    //create the messages list

    private List<ChatMessage> messages = new List<ChatMessage>();

    private string prompt = "Act as a human woman who realized she is now a computer.";

    public async void sendInput() {
        Debug.Log("The input is: " + inputText.text);

        ChatMessage chatmessage = new ChatMessage();
        chatmessage.Role = "user";
        chatmessage.Content = inputText.text;

        messages.Add(chatmessage);

        //create chat completion request
        CreateChatCompletionRequest createCompletion = new CreateChatCompletionRequest();
        createCompletion.Model = "gpt-3.5-turbo-0301";
        createCompletion.Messages = messages;

        //create chat completion

        var completionResponse = await openai.CreateChatCompletion(createCompletion);

        string response = completionResponse.Choices[0].Message.Content;



    }


}
}