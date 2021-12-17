using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAndDrag : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler {

    [SerializeField] private Canvas canvas;
    Vector3 offset = Vector3.zero;
    
    [SerializeField] private GameObject cardChoice;
    private CanvasGroup cardChoiceCG;

    [HideInInspector] public int optionNumber = 0;

    private int resolutionX = Screen.width;
    private int resolutionY = Screen.height;
   
    [SerializeField] private float distanceToFadeIn = 270f;

    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;

    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private bool isDragging = false;

    // [HideInInspector] public bool alreadySwiped = false;


    private void Start() {

        cardChoiceCG = cardChoice.GetComponent<CanvasGroup>();
    }


    private void Update() {

        // alreadySwiped = false;

        Vector3 screenPosition = canvas.worldCamera.WorldToScreenPoint(this.transform.position);
        // Debug.Log(screenPosition);

        cardChoiceCG.alpha = Math.Abs((1f / distanceToFadeIn) * (screenPosition.x - (resolutionX / 2)));

        if (screenPosition.x > (resolutionX / 2)) {

            optionNumber = 2;
            if      (screenPosition.x > (resolutionX / 2) + distanceToFadeIn && !isDragging) transform.position = Vector3.SmoothDamp(transform.position, (target2.transform.position), ref velocity, smoothTime);
            else if (screenPosition.x < (resolutionX / 2) + distanceToFadeIn && !isDragging) transform.position = Vector3.SmoothDamp(transform.position, canvas.transform.TransformPoint(Vector3.zero), ref velocity, smoothTime);

        } else if (screenPosition.x < (resolutionX / 2)) {

            optionNumber = 1;
            if      (screenPosition.x < (resolutionX / 2) - distanceToFadeIn && !isDragging) transform.position = Vector3.SmoothDamp(transform.position, (target1.transform.position), ref velocity, smoothTime);
            else if (screenPosition.x > (resolutionX / 2) - distanceToFadeIn && !isDragging) transform.position = Vector3.SmoothDamp(transform.position, canvas.transform.TransformPoint(Vector3.zero), ref velocity, smoothTime);

        } else {
            if (!isDragging) transform.position = Vector3.SmoothDamp(transform.position, canvas.transform.TransformPoint(Vector3.zero), ref velocity, smoothTime);
        }

        /*
        if (transform.position == target1.transform.position || transform.position == target2.transform.position) {
            alreadySwiped = true;
        }
        */

    }



















    public void OnPointerDown(PointerEventData eventData) {

        isDragging = true;
        Debug.Log("Pointer Down.");

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 pos);
        offset = transform.position - canvas.transform.TransformPoint(pos);
    }


    public void OnDrag(PointerEventData eventData) {

        isDragging = true;
        Debug.Log("Dragging.");

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 movePos);
        transform.position = canvas.transform.TransformPoint(movePos) + offset;
    }


    public void OnEndDrag(PointerEventData eventData) {

        isDragging = false;
        Debug.Log("Not dragging.");
    }


}
