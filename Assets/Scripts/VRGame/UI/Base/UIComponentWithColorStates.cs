using UnityEngine;
using UnityEngine.UI;

namespace VRGame.UI.Base
{
    public class UIComponentWithColorStates : UIComponentWithStates
    {
        [SerializeField] private Image m_Image;

        [SerializeField] private Color m_FocusColor;
        [SerializeField] private Color m_UnFocusColor;

        protected override void OnFocus()
        {
            base.OnFocus();
            SetImageColor(m_FocusColor);
        }

        protected override void OnUnFocus()
        {
            base.OnUnFocus();
            SetImageColor(m_UnFocusColor);
        }

        private void SetImageColor(Color color)
        {
            m_Image.color = color;
        }
    }
}
