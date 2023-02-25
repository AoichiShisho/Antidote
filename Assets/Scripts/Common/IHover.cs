    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
     
    public abstract class IHover : MonoBehaviour
    {
        private DateTime mouseEnter;
        public TimeSpan HOVER_THRESHOLD = TimeSpan.FromMilliseconds(100);
        private bool isMousedOver;

        public abstract void DoHoverAction();
        public abstract void StopHoverAction();

        public virtual void Update()
        {
            if (IsPointerOverElement())
            {
                if (!isMousedOver) {
                    isMousedOver = true;
                    mouseEnter = DateTime.Now;
                }
            } else if (isMousedOver)
            {
                isMousedOver = false;
                StopHoverAction();
            }
            if (isMousedOver && DateTime.Now - mouseEnter > HOVER_THRESHOLD) DoHoverAction();
        }

        //Returns 'true' if we touched or hovering on Unity UI element.
        public bool IsPointerOverElement()
        {
            return IsPointerOverElement(GetEventSystemRaycastResults());
        }
     
     
        private bool IsPointerOverElement(List<RaycastResult> eventSystemRaysastResults)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaysastResults[index];
                if (curRaysastResult.gameObject.GetInstanceID() == gameObject.GetInstanceID())
                    return true;
            }
            return false;
        }
     
     
        //Gets all event system raycast results of current mouse or touch position.
        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }
     
    }
     
