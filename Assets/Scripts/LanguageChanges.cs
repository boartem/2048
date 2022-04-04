using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Text;

public class LanguageChanges : MonoBehaviour
{
    private textFile mainText;
    private string json;

    void Start()
    {
        loadFileEN();
    }

    public void changed()
    {
        int choice = GameObject.FindGameObjectWithTag("dropDown").GetComponent<Dropdown>().value;
        if(choice==0)
        {
            loadFileEN();
        }
        else
        {
            loadFileRU();
        }
    }

    public void sceneChanged()
    {
        SceneManager.LoadScene("Game");
    }

    private void readingFile(string fileName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        WWW reader = new WWW(path);
        while (!reader.isDone) { }
        json = reader.text;
        mainText = JsonUtility.FromJson<textFile>(json);
        
    }

    public void loadFileEN()
    {
        readingFile("EN.json");
        textChanges();
    }

    public void loadFileRU()
    {
        readingFile("RU.json");
        textChanges();
    }

    private void textChanges()
    {
        GameObject.FindGameObjectWithTag("text1").GetComponent<Text>().text = mainText.button1;
    }

    private class textFile
    {
        public string button1;
    }
}
