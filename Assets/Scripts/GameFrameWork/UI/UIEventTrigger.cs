using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace GameFrameWork.UI
{
    public class UIEventTrigger : EventTrigger
    {
        public enum UIEventType
        {
            Click,
            DounbeClick,
            Select,
            Deselect,
            Drag,
            DragEnd,
            Drop,
            Press,
            LongPress,
            CursorEnter,
            CursorExit,
            Scroll
        };

        public void BindUIEvent(UIEventType eType, System.Action callBack)
        {
            switch (eType)
            {
                case UIEventType.Click:
                    OnPointerClickAction += callBack;
                    break;
                case UIEventType.DounbeClick:                    
                    OnPointerDoubleClickAction += callBack;
                    break;
                case UIEventType.Select:
                    OnSelectAction += callBack;
                    break;
                case UIEventType.Deselect:
                    OnDeselectAction += callBack;
                    break;
                case UIEventType.Drag:
                    OnDragAction += callBack;
                    break;
                case UIEventType.DragEnd:
                    OnEndDragAction += callBack;
                    break;
                case UIEventType.Drop:
                    OnDropAction += callBack;
                    break;
                case UIEventType.Press:
                    OnPointerDownAction += callBack;
                    break;
                case UIEventType.LongPress:
                    OnLongPressAction += callBack;
                    break;
                case UIEventType.CursorEnter:
                    OnPointerEnterAction += callBack;
                    break;
                case UIEventType.CursorExit:
                    OnPointerExitAction += callBack;
                    break;
                case UIEventType.Scroll:
                    OnScrollAction += callBack;
                    break;
            }
        }

        public void UnbindUIEvent(UIEventType eType, System.Action callBack)
        {
            switch (eType)
            {
                case UIEventType.Click:
                    OnPointerClickAction -= callBack;
                    break;
                case UIEventType.DounbeClick:
                    OnPointerDoubleClickAction -= callBack;
                    break;
                case UIEventType.Select:
                    OnSelectAction -= callBack;
                    break;
                case UIEventType.Deselect:
                    OnDeselectAction -= callBack;
                    break;
                case UIEventType.Drag:
                    OnDragAction -= callBack;
                    break;
                case UIEventType.DragEnd:
                    OnEndDragAction -= callBack;
                    break;
                case UIEventType.Drop:
                    OnDropAction -= callBack;
                    break;
                case UIEventType.Press:
                    OnPointerDownAction -= callBack;
                    break;
                case UIEventType.LongPress:
                    OnLongPressAction -= callBack;
                    break;
                case UIEventType.CursorEnter:
                    OnPointerEnterAction -= callBack;
                    break;
                case UIEventType.CursorExit:
                    OnPointerExitAction -= callBack;
                    break;
                case UIEventType.Scroll:
                    OnScrollAction -= callBack;
                    break;
            }
        }


        private float pointerDownTime = 0.0f;
        public event System.Action OnPointerDownAction;
        public override void OnPointerDown(PointerEventData eventData)
        {
            pointerDownTime = Time.time;
            if (OnPointerDownAction != null)
                OnPointerDownAction();
        }

        public event System.Action OnPointerUpAction;
        public event System.Action OnLongPressAction;
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (OnPointerUpAction != null)
                OnPointerUpAction();

            if (Time.time - pointerDownTime > 0.5 && eventData.pressPosition == eventData.position)
            {
                if (OnLongPressAction != null)
                    OnLongPressAction();
            }
        }

        public event System.Action OnPointerEnterAction;
        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (OnPointerEnterAction != null)
                OnPointerEnterAction();
        }

        public event System.Action OnPointerExitAction;
        public override void OnPointerExit(PointerEventData eventData)
        {
            if (OnPointerExitAction != null)
                OnPointerExitAction();
        }

        public event System.Action OnPointerClickAction;
        public event System.Action OnPointerDoubleClickAction;
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount == 2)
            {
                if (OnPointerDoubleClickAction != null)
                    OnPointerDoubleClickAction();
            }
            else
            {
                if (OnPointerClickAction != null)
                    OnPointerClickAction();
            }
        }

        public event System.Action OnBeginDragAction;
        public override void OnBeginDrag(PointerEventData e)
        {
            if (OnBeginDragAction != null)
                OnBeginDragAction();
        }

        public event System.Action OnDragAction;
        public override void OnDrag(PointerEventData eventData)
        {
            if (OnDragAction != null)
                OnDragAction();
        }

        public event System.Action OnEndDragAction;
        public override void OnEndDrag(PointerEventData eventData)
        {
            if (OnEndDragAction != null)
                OnEndDragAction();
        }

        public event System.Action OnCancelAction;
        public override void OnCancel(BaseEventData eventData)
        {
            if (OnCancelAction != null)
                OnCancelAction();
        }

        public event System.Action OnMoveAction;
        public override void OnMove(AxisEventData eventData)
        {
            if (OnMoveAction != null)
                OnMoveAction();
        }

        public event System.Action OnSelectAction;
        public override void OnSelect(BaseEventData eventData)
        {
            if (OnSelectAction != null)
                OnSelectAction();
        }

        public event System.Action OnUpdateSelectedAction;
        public override void OnUpdateSelected(BaseEventData eventData)
        {
            if (OnUpdateSelectedAction != null)
                OnUpdateSelectedAction();
        }

        public event System.Action OnDeselectAction;
        public override void OnDeselect(BaseEventData eventData)
        {
            if (OnDeselectAction != null)
                OnDeselectAction();
        }

        public event System.Action OnSumitAction;
        public override void OnSubmit(BaseEventData eventData)
        {
            if (OnSumitAction != null)
                OnSumitAction();
        }

        public event System.Action OnScrollAction;
        public override void OnScroll(PointerEventData eventData)
        {
            if (OnScrollAction != null)
                OnScrollAction();
        }

        public event System.Action OnDropAction;
        public override void OnDrop(PointerEventData eventData)
        {
            if (OnDropAction != null)
                OnDropAction();
        }

    }
}