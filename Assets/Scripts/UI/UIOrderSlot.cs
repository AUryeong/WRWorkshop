using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIOrderSlot : MonoBehaviour, IPointerClickHandler
{
    public bool isCheck { get; private set; }

    public Button.ButtonClickedEvent clickAction;
    Vector3 checkPos = new Vector2(27.5f, 40);

    Transform _checkTransform;
    Transform checkTransform
    {
        get
        {
            if (_checkTransform == null)
            {
                _checkTransform = transform.parent.GetChild(transform.parent.childCount - 1);
            }
            return _checkTransform;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isCheck)
        {
            foreach (UIOrderSlot uiOrderSlot in transform.parent.GetComponentsInChildren<UIOrderSlot>(true))
            {
                if (uiOrderSlot.isCheck)
                {
                    uiOrderSlot.isCheck = false;
                    break;
                }
            }
            isCheck = true;
            checkTransform.localPosition = checkPos + transform.localPosition;
            checkTransform.gameObject.SetActive(true);
        }
        else
        {
            isCheck = false;
            checkTransform.gameObject.SetActive(false);
        }
        clickAction.Invoke();
    }
}
