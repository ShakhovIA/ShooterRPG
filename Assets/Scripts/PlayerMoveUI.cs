using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool isRotationCamera = false;

    public Player player;
    public Transform cameraTransform;

    public GameObject spriteJoystick;
    public RectTransform rootRect;
    public RectTransform spriteJoystickRectAll;
    public RectTransform spriteJoystickRect;

    public float factor = 1f;

    Vector2 posTemp = Vector2.zero;

    Vector3 tempVect3 = Vector3.zero;

    void FixedUpdate()
    {
        if(!isRotationCamera)
            player.Move(tempVect3);
    }

    void Update()
    {
        if (isRotationCamera)
        {
#if UNITY_EDITOR
            tempVect3.x = 0f;
            tempVect3.y = 0f;
            tempVect3.z = Mathf.Clamp(cameraTransform.localPosition.z + Input.mouseScrollDelta.y, -2f, 3f);
            cameraTransform.localPosition = tempVect3;
#else
            UpdateWithTouch();
#endif
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (!isRotationCamera)
        {
            posTemp += data.delta * factor;

            posTemp = Vector2.ClampMagnitude(posTemp, 30f);

            spriteJoystickRect.anchoredPosition = posTemp;

            tempVect3.x = posTemp.x;
            tempVect3.y = 0f;
            tempVect3.z = posTemp.y;
        }
        else
        {
            player.transformPlayer.Rotate(Vector3.up, data.delta.x * factor);
            player.transformRotationPlayer.Rotate(Vector3.up, -data.delta.x * factor);
        }
    }


    public void OnPointerUp(PointerEventData data)
    {
        if (isRotationCamera)
            return;

        spriteJoystick.SetActive(false);

        tempVect3 = Vector3.zero;
    }


    public void OnPointerDown(PointerEventData data)
    {
        if (isRotationCamera)
            return;

        spriteJoystick.SetActive(true);
        posTemp = Vector2.zero;
        spriteJoystickRect.anchoredPosition = Vector2.zero;

        
        spriteJoystickRectAll.anchoredPosition = data.position * (1f / rootRect.localScale.x);
    }



    void UpdateWithTouch()
    {
        int touchCount = Input.touches.Length;

        if (touchCount == 2)
        {
            Touch touch0 = Input.touches[0];
            Touch touch1 = Input.touches[1];

            if (touch0.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Ended) return;

            float previousDistance = Vector2.Distance(touch0.position - touch0.deltaPosition, touch1.position - touch1.deltaPosition);

            float currentDistance = Vector2.Distance(touch0.position, touch1.position);

            if (previousDistance != currentDistance)
            {
                OnPinch((touch0.position + touch1.position) / 2, previousDistance, currentDistance, (touch1.position - touch0.position).normalized);
            }
        }
    }
    void OnPinch(Vector2 center, float oldDistance, float newDistance, Vector2 touchDelta)
    {
        tempVect3.x = 0f;
        tempVect3.y = 0f;
        tempVect3.z = Mathf.Clamp(cameraTransform.localPosition.z * (oldDistance / newDistance) * (oldDistance > newDistance ? -100f : 100f), -2f, 3f);
        cameraTransform.localPosition = tempVect3;
    }
}
