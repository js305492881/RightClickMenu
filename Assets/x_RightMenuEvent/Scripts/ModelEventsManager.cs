using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace xxl.xiesi
{
    public class ModelEventsManager : MonoBehaviour, IPointerClickHandler
    {
        public static ModelEventsManager s_instance;
        public RectTransform m_rtfMenuRoot;

        // 加载脚本实例时调用 Awake
        private void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this;
            }
            else
            {
                Debug.LogError("FUCK");
            }
        }

        public static void Load(ModelEvents _me, Vector2 _v2Position)
        {
            if (s_instance == null)
            {
                GameObject v_go = Instantiate(Resources.Load("RightMenuEvent/ModelEventsManager")) as GameObject;
                ModelEventsManager v_mem = v_go.GetComponent<ModelEventsManager>();
            }
            s_instance.Load(_me, _v2Position);
        }

        public void Load(ModelEvents _me, Vector2 _v2Position, bool _bFuck = false)
        {
            for (int i = m_rtfMenuRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(m_rtfMenuRoot.GetChild(i).gameObject);
            }

            m_rtfMenuRoot.anchoredPosition = _v2Position;

            foreach (ModelEventsType item in _me.m_list_events)
            {
                LoadButton(item);
            }

            foreach (ModelValueType item in _me.m_list_Values)
            {
                ModelEventsSlider.Load(item, m_rtfMenuRoot.transform);
            }
        }

        private void LoadButton(ModelEventsType _met)
        {
            GameObject v_go = Instantiate(Resources.Load("RightMenuEvent/ModelEventsButton"), m_rtfMenuRoot.transform) as GameObject;
            ModelEventsButton v_meb = v_go.GetComponent<ModelEventsButton>();
            v_meb.m_text.text = _met.m_strButtonName;
            v_meb.onClick.AddListener(() =>
            {
                _met.m_evnet.Invoke();
            });
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Destroy(gameObject);
        }
    }
}
