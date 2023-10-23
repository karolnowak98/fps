using UnityEngine;

namespace FPS.Core.UI
{
    public class Panel : MonoBehaviour
    {
        protected void Show() => gameObject.SetActive(true);
        protected void Hide() => gameObject.SetActive(false);
    }
}