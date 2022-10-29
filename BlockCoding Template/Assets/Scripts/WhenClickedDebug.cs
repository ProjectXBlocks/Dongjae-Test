using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WhenClickedDebug : MonoBehaviour, IPointerDownHandler
{
    int num = 0;
    bool isCollide = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Add")
        {
            List<int> temp = collision.gameObject.GetComponent<AddNum>().numlist;

            num = 0;

            foreach(int i in temp)
            {
                num += i;
            }

            isCollide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollide = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isCollide)
        {
            Debug.Log(num);
        }
        //throw new System.NotImplementedException();
    }
}
