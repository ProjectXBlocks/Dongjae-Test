using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //public static Vector2 defaultposition;
    public bool isDrag;
    Transform trans;
    BoxCollider2D box;
    private void Start()
    {
        trans = GetComponent<Transform>();
        box = GetComponent<BoxCollider2D>();
        isDrag = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bin")
        {
            Destroy(gameObject);
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)//드래그시작할 때
    {
        if (!isDrag)
        {
            GameObject newInputField = Instantiate(gameObject, trans.position, trans.rotation);
            newInputField.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;
            newInputField.transform.localScale = Vector3.one;
            //defaultposition = this.transform.position;
            isDrag = true;
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)//드래그중일 때
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)//드래그 끝났을 때
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //this.transform.position = defaultposition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
