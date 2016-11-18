using UnityEngine;
using System.Collections;

public class ButtonInfo : MonoBehaviour
{
    public ChatList chatList;
    public string sceneName  = "";

    public static string currentScene = "start1";
    
    public void Start()
    {
        GameObject obj = GameObject.Find("ChatList_obj");
        chatList = obj.GetComponent<ChatList>();
    }

	public void onClick()
    {
        if(sceneName.Equals(""))
        {
            return;
        }

        chatList.GetContent(sceneName);
        
    }

    public void onTestClick()
    {
        chatList.AddChatBar(currentScene);
    }
}
