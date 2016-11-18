using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;

[RequireComponent(typeof(UIGrid))]

public class ChatList : MonoBehaviour
{
    //public int _exp = 0;

    public GameObject chatBarObj;
    public ButtonPanel btnsPanel;

    //public GameObject buttonObj;

    //private string selectedScene = "start2";
    private UIGrid uiGrid;

    //private ChatBar chatBar;
    private Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>(); 
    //private int maxPage;
    private string[] title;

    private UIButton button;
    public ButtonPanel panel;

    void TabParsing()
    {

        try
        {
            string line;
            Debug.Log(Application.dataPath);

            StreamReader reader = new StreamReader(Application.dataPath + "/Resources/DataTab.tsv", Encoding.UTF8);

            //StreamReader reader = new StreamReader(filePath);

            using (reader)
            {
                for (int i = 0; ; i++)
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        string[] single = line.Split('\t');

                        if (i == 0)
                        {
                            title = single;
                        }
                        else
                        {
                            if (single.Length > 0)
                            {
                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                for (int col = 1; col < single.Length; col++)
                                {
                                    dic.Add(title[col], single[col]);
                                }
                                Debug.Log(single[0]);  
                                data.Add(single[0], dic);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                reader.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    void Awake()
    {
        this.uiGrid = this.GetComponent<UIGrid>();
        //chatBar = GetComponent<ChatBar>();
        //AddChatBar();
    }

    void Start()
    {
        //panel = GetComponent<ButtonPanel>();
        //UnityEngine.Events.UnityAction action= (string eventName) =>
        //{
        //    clickHandler(eventName);
        //};
        //panel.addListener();

        TabParsing();
        
        //data = CSVReader.Read("DataTab.");

        Debug.Log(data);
        //maxPage = data.Count;
        //Debug.Log("max : " + maxPage);

        //for (var i = 0; i < dataCnt; i++)
        //{
        //    // Debug.Log("index" + (i).ToString() + " : " + data[i]["Scene"] + " " + data[i]["Event"] + " " + data[i]["Choice"] + data[i]["Speaker"] + data[i]["Korean"]);
        //    //text.text = "12345";
        //    //Debug.Log("1");

        //    GameObject newChatBarObj = Instantiate(
        //        this.chatBarObj,
        //        this.transform.position,
        //        Quaternion.identity) as GameObject;
        //    UILabel text = newChatBarObj.GetComponentInChildren<UILabel>();
        //    text.text = (i).ToString() + data[i]["Scene"] + data[i]["Speaker"];

        //    Debug.Log(data[i]["Scene"]);
        //    //dataCnt = (int)data[1]["Scene"];
        //    //Debug.Log(dataCnt);

        //    //text
        //}
        //for (var i = 0; i < data.Count; i++)
        //{
        //    // Debug.Log("index" + (i).ToString() + " : " + data[i]["Scene"] + " " + data[i]["Event"] + " " + data[i]["Choice"] + data[i]["Speaker"] + data[i]["Korean"]);

        //}

        //_exp = (int)data[0]["Scene"];

        //Debug.Log(_exp);
    }

    public void AddChatBar(string sceneName)
    {
        if(data[sceneName] == null)
        {
            print("data[" +sceneName+"]"+ "is none");
            return;
        }
        if(sceneName ==null ||  sceneName.Equals(""))
        {
            print(sceneName + "is none");
            return;
        }

        GameObject newChatBarObj = Instantiate(
            this.chatBarObj,
            this.transform.position, 
            Quaternion.identity) as GameObject;
        //새로생성된 채팅바의 부모는 나 자신이다.
        newChatBarObj.transform.SetParent(this.transform);
        //스케일 초기화
        newChatBarObj.transform.localScale = new Vector3(1, 1, 1);


        Debug.Log("selected:" + sceneName);
        Debug.Log("data scene:" + data[sceneName]);

        UILabel text = newChatBarObj.GetComponentInChildren<UILabel>();
        text.text = data[sceneName]["Content"] /*+ data[currentPage]["Speaker"]*/;

        string choice = data[sceneName]["Choice"];
        if (choice == "")
        {

            sceneName = data[sceneName]["Event"];
            //StartCoroutine(waiting());
            Debug.Log("sceneName :  " + sceneName);
            ButtonInfo.currentScene = sceneName;
            //AddChatBar();           
            //this.uiGrid.Reposition();

        }
        else
        {

            Debug.Log("choice != null");

            string[] events = data[sceneName]["Event"].Split('/');
            string[] buttons = choice.Split('/');

            Debug.Log(buttons);

            panel.makeButton(buttons.Length, buttons, events);

            //panel.makeButtons();
            //ButtonPanel.makeButton(buttons.Length, buttons);
        }


        //ChatBar newBar = newChatBarObj.GetComponent<ChatBar>();

        //정렬
        this.uiGrid.Reposition();
    
}
    public void AddChattingBar(/*string[] events*/)
    {
        GameObject newChatBarObj = Instantiate(
           this.chatBarObj,
           this.transform.position,
           Quaternion.identity) as GameObject;
        //새로생성된 채팅바의 부모는 나 자신이다.
        newChatBarObj.transform.SetParent(this.transform);
        //스케일 초기화
        newChatBarObj.transform.localScale = new Vector3(1, 1, 1);
    }
    public  void GetContent(string sceneName)
    {
        string content = data[sceneName]["Content"];
        print(content);

        string[] events = data[sceneName]["Event"].Split('/');

        btnsPanel.SetButtonInactivate();
        if (events.Length == 1)
            AddChatBar(events[0]);
        //if (events.Length == 2)
        //{

        //}
        //    if (events.Length == 3)
        //{

        //}

    }

 //   IEnumerator waiting()
 //   {
 //       yield return new WaitForSeconds(1);
 //   }

 //   IEnumerator DeleteAfterReposition()
 //   {
 //       yield return null;
 //       //정렬
 //       this.uiGrid.Reposition();
 //   }
 //   void Update ()
 //   {
	
	//}
}
