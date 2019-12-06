using UnityEngine;
using UnityEngine.UI;

namespace xxl.xiesi
{
    public class ModelEventsButton : MonoBehaviour
    {
        public Button.ButtonClickedEvent onClick;
        public Button m_button;
        public Text m_text;

        // 加载脚本实例时调用 Awake
        private void Awake()
        {
            m_button.onClick.AddListener(() =>
            {
                onClick.Invoke();
            });
        }
    }
}