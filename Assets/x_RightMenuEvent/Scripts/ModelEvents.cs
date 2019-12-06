using HighlightingSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace xxl.xiesi
{
    [RequireComponent(typeof(Highlighter))]
    public class ModelEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public enum 弹出位置
        {
            鼠标上,
            物体上,
            物体的右上角
        }

        public 弹出位置 m_弹出位置 = 弹出位置.鼠标上;
        public List<ModelEventsType> m_list_events;
        public List<ModelValueType> m_list_Values;
        private Highlighter m_highlighter;

        // 加载脚本实例时调用 Awake
        private void Awake()
        {
            m_highlighter = GetComponent<Highlighter>();
        }



        public void OnPointerEnter(PointerEventData eventData)
        {
            m_highlighter.TweenStart();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_highlighter.TweenStop();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("<b>屏幕位置</b>" + Get屏幕位置(eventData));
            ModelEventsManager.Load(this, Get屏幕位置(eventData));
        }

        private Vector2 Get屏幕位置(PointerEventData eventData)
        {
            switch (m_弹出位置)
            {
                case 弹出位置.鼠标上:
                    return eventData.position;
                case 弹出位置.物体上:
                    return eventData.pressEventCamera.WorldToScreenPoint(transform.position);
                case 弹出位置.物体的右上角:
                    return eventData.pressEventCamera.WorldToScreenPoint(transform.position) + new Vector3(50.0f, 0.0f);
                default:
                    break;
            }
            return Vector2.zero;
        }
    }

    [Serializable]
    public class ModelEventsType
    {
        public string m_strButtonName;
        public UnityEvent m_evnet;
    }

    [Serializable]
    public class ModelValueType
    {
        public string m_strValueName;
        public float m_fMaxValue;
        public float m_fMinValue;
        public float m_fValue;
        public bool m_b真可调节否不可调节 = false;
        public bool m_b真显示百分号否不显示百分号 = true;
        public int m_n保留几位小数 = 2;
    }
}