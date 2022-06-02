using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    public RectTransform joystickTransform;

    public Vector3 inputVector;

    public bool moveInput = false;

    [SerializeField]
    private int dragMovementDistant = 30;
    [SerializeField]
    private int dragOffsetDistant = 100;

    public event Action<Vector2> onMove;

    #region event
    public void OnDrag(PointerEventData eventData)   //change the position of joybutton(vector)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickTransform,
            eventData.position,
            null,
            out offset);
            
        moveInput = true;
        //change the position of joybutton(image)
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistant) / dragOffsetDistant;
        //Debug.Log(offset);


        joystickTransform.anchoredPosition = offset * dragMovementDistant;

        inputVector = new Vector3(offset.x * 4, 0, offset.y *4);
        //bug.Log(inputVector);
        inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized:inputVector;
    }


    public void OnPointerDown(PointerEventData pad)
    {
        OnDrag(pad);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTransform.anchoredPosition = Vector2.zero;
        onMove?.Invoke(Vector2.zero);
        //Debug.Log("pointer up");
        moveInput = false;
    }
    #endregion

 
    
    private void Awake() 
    {
        joystickTransform = (RectTransform)transform;
    }
    #region input
    public float Vectical()
    {
        if(inputVector.z != 0 && moveInput)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
    public float Horizontal()
    {
        if(inputVector.x != 0 && moveInput)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    #endregion
    

}
