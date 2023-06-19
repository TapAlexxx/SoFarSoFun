using UnityEngine;
using UnityEngine.UI;

namespace Window.MenuButtons
{

    public class ExitButton : MonoBehaviour
    {
        [SerializeField] public Button button;

        private void Start()
        {
            button.onClick.AddListener(QuitGame);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }

}