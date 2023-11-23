using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using UnityEngine.Events;

public class ChatGPTManager : MonoBehaviour
{

    public string personality;
    public string scene;
    public int maxResponseWordLimit = 15;

    public OnResponseEvent onResponse;

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { }

    // Create an instance of the OpenAIApi class.
    private OpenAIApi openAI = new OpenAIApi();
    // Create a list to store chat messages.
    private List<ChatMessage> messages = new List<ChatMessage>();

    // Method for sending user input to GPT-3.5 for completion.
    public async void AskChatGPT(string newText)
    {
        // Create a new ChatMessage object.
        ChatMessage newMessage = new ChatMessage();
        // Set the content of the new message to the provided text.
        newMessage.Content = newText;
        // Set the role of the message to "user".
        newMessage.Role = "user";

        // Add the new message to the list of messages.
        messages.Add(newMessage);

        // Create a new request for chat completion.
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        // Set the messages for the completion request.
        request.Messages = messages;
        // Set the model to use for chat completion.
        request.Model = "gpt-3.5-turbo";

        // Perform the chat completion and await the response.
        var response = await openAI.CreateChatCompletion(request);

        // Check if the response contains choices.
        if (response.Choices != null && response.Choices.Count > 0)
        {
            // Get the first message choice from the response.
            var chatResponse = response.Choices[0].Message;
            // Add the chat response to the list of messages.
            messages.Add(chatResponse);
            // Output the content of the chat response to the console.
            Debug.Log(chatResponse.Content);
            onResponse.Invoke(chatResponse.Content);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // This method is called when the script starts. It can be used for initialization.
    }

    // Update is called once per frame
    void Update()
    {
        // This method is called once per frame. It can be used for game logic that needs to be updated each frame.
    }
}
