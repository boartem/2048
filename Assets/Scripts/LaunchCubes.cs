using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LaunchCubes : MonoBehaviour
{
    [SerializeField] GameObject cube;
    GameObject newCube;
    private Vector2 startPosition;
    private Vector2 currentPosition;
    private float maxAxisX;
    private float maxAxisY;
    private bool isLive;
    private int numberLaunches = 1;

    void Start()
    {
        maxAxisX = Screen.width * 0.6f;
        maxAxisY = Screen.height;
        isLive = false;

        InterstitialAd.S.LoadAd();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    newCube = Instantiate(cube, new Vector3(12, 1, (touch.position.x - Screen.width / 2) / (Screen.width / 8)), Quaternion.identity);
                    startPosition = touch.position;
                    currentPosition = new Vector2(0,0);
                    isLive = true;
                    break;

                case TouchPhase.Moved:
                    if (isLive)
                    {
                        currentPosition += touch.deltaPosition;
                        newCube.transform.position = new Vector3(newCube.transform.position.x, newCube.transform.position.y, (touch.position.x - Screen.width / 2) / (Screen.width / 8));

                        if (currentPosition.y >= maxAxisY * 0.15)
                        {
                            newCube.GetComponent<Cube>().isActiveMove = true;
                            GameObject.FindGameObjectWithTag("text2").GetComponent<Text>().text = (int.Parse(GameObject.FindGameObjectWithTag("text2").GetComponent<Text>().text) + 2).ToString();
                            newCube = null;
                            isLive = false;
                            numberLaunches++;
                            if(numberLaunches%10==0)
                            {
                                InterstitialAd.S.ShowAd();
                            }
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if(isLive)
                        Destroy(newCube);
                    break;
            }
        }
    }
}
