using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNum : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public List<int> numlist = new List<int>();

    List<int> numberlist = new List<int>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "InputNumber")
        {
            gameObjects.Add(collision.gameObject);
            //Debug.Log(collision.gameObject.GetComponentInChildren<InputField>().text);
            //numlist.Add(Convert.ToInt32(collision.gameObject.GetComponentInChildren<InputField>().text)); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "InputNumber")
        {
            gameObjects.Remove(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        List<int> numberlist = new List<int>();

        for (int i = 0; i < gameObjects.Count; i++)
        {
            numberlist.Add(0);
        }

        for (int i = 0; i < gameObjects.Count; i++)
        {
            numberlist[i] = Convert.ToInt32(gameObjects[i].GetComponentInChildren<InputField>().text);
        }

        numlist = numberlist;
    }
}
