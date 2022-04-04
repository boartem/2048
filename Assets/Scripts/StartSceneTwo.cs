using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneTwo : MonoBehaviour
{
    bool firstTime = true;
    public List<cubeSettings> listCubeSettings = new List<cubeSettings>();
    void Start()
    {
        
        listCubeSettings.Add(new cubeSettings { number = 2, color = Color.red });
        listCubeSettings.Add(new cubeSettings { number = 4, color = Color.yellow });
        listCubeSettings.Add(new cubeSettings { number = 8, color = Color.blue });
        listCubeSettings.Add(new cubeSettings { number = 16, color = Color.green });
        listCubeSettings.Add(new cubeSettings { number = 32, color = Color.gray });
        listCubeSettings.Add(new cubeSettings { number = 64, color = Color.cyan });
    }

    private void Update()
    {
        if (firstTime)
        {
            int score = 0;
            GameObject[] start = GameObject.FindGameObjectsWithTag("cube");
            foreach (GameObject cube in start)
            {
                score += cube.GetComponent<Cube>().number;
            }
            GameObject.FindGameObjectWithTag("text2").GetComponent<Text>().text = score.ToString();
            firstTime = false;
        }
    }

    public struct cubeSettings
    {
        public int number;
        public Color color;
    }
}
