using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace xxl.xiesi
{
    public class ModelEventsSlider : MonoBehaviour
    {
        public Slider m_slider;
        public Text m_text;
        public ModelValueType m_mvt;
        //private bool m_b真鼠标按下否鼠标抬起 = false;

        // 加载脚本实例时调用 Awake
        private void Awake()
        {
            m_slider.onValueChanged.AddListener((float _arg0) =>
            {
                if (m_mvt.m_b真显示百分号否不显示百分号)
                {
                    m_text.text = m_mvt.m_strValueName + (m_slider.value * 100).ToString("f" + m_mvt.m_n保留几位小数.ToString()) + "%";
                }
                else
                {
                    m_text.text = m_mvt.m_strValueName + m_slider.value.ToString("f" + m_mvt.m_n保留几位小数.ToString());
                }

                //if (m_b真鼠标按下否鼠标抬起)
                if (Input.GetMouseButton(0))
                {
                    m_mvt.m_fValue = m_slider.value;
                }
            });
        }

        public static void Load(ModelValueType _mvt, Transform _tfRoot)
        {
            GameObject v_go = Instantiate(Resources.Load("RightMenuEvent/ModelEventsSlider"), _tfRoot) as GameObject;
            ModelEventsSlider v_mes = v_go.GetComponent<ModelEventsSlider>();

            v_mes.m_mvt = _mvt;
            v_mes.m_slider.maxValue = _mvt.m_fMaxValue;
            v_mes.m_slider.minValue = _mvt.m_fMinValue;
            v_mes.m_slider.value = _mvt.m_fValue;
            if (!_mvt.m_b真可调节否不可调节)
            {
                v_mes.m_slider.interactable = false;
            }

            if (v_mes.m_mvt.m_b真显示百分号否不显示百分号)
            {
                v_mes.m_text.text = v_mes.m_mvt.m_strValueName + (v_mes.m_slider.value * 100).ToString("f" + v_mes.m_mvt.m_n保留几位小数.ToString()) + "%";
            }
            else
            {
                v_mes.m_text.text = v_mes.m_mvt.m_strValueName + v_mes.m_slider.value.ToString("f" + v_mes.m_mvt.m_n保留几位小数.ToString());
            }
        }

        // 如果 MonoBehaviour 已启用，则在每一帧都调用 Update
        private void Update()
        {
            //if (!m_b真鼠标按下否鼠标抬起)
            if (!Input.GetMouseButton(0))
            {
                m_slider.value = m_mvt.m_fValue;
            }
        }
    }
}