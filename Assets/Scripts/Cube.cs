using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public int number;
    public bool isActiveMove;

    void Start()
    {
        isActiveMove = false;
        number = 2;
    }

    void Update()
    {
        if(isActiveMove)
        {
            move();
        }
    }

    public void nextNumber()
    {
        number *= 2;
        int power = 0;
        for (int i = 1; i < number;i++)
        {
            i <<= 1;
            power++;
        }
        Debug.Log(power);
        int listCount = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StartSceneTwo>().listCubeSettings.Count;
        if (listCount > power)
            gameObject.GetComponent<Renderer>().material.color = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StartSceneTwo>().listCubeSettings[power-1].color;
        else
            gameObject.GetComponent<Renderer>().material.color = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StartSceneTwo>().listCubeSettings[listCount-1].color;

        for (int i = 0; i < 6; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<TextMeshPro>().text = number.ToString();
        }
    }

    private void move()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(-2, 0, 0)*Time.deltaTime*5);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if(collision.gameObject.tag == "cube")
        {
            if(isActiveMove)
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-3, 0, 0, ForceMode.Impulse);
            isActiveMove = false;            
            if (number==collision.gameObject.GetComponent<Cube>().number)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Cube>().nextNumber();
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0,6,0,ForceMode.Impulse);
            }
        }
        else if(collision.gameObject.tag == "wall")
        {
            if (isActiveMove)
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-3, 0, 0, ForceMode.Impulse);
            isActiveMove = false;
        }
    }
}
