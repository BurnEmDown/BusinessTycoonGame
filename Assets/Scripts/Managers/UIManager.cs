using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject managersPanel;
        
        public static UIManager Instance;
        private GameManager gameManager => GameManager.Instance;

        public UIState CurrentState;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            CurrentState = UIState.Main;
        }


        void OnShowManagers()
        {
            CurrentState = UIState.Managers;
            managersPanel.SetActive(true);
        }

        void OnShowMain()
        {
            CurrentState = UIState.Main;
            managersPanel.SetActive(false);
        }

        public void OnClickManagers()
        {
            if (CurrentState == UIState.Main)
            {
                OnShowManagers();
            }
            else if (CurrentState == UIState.Managers)
            {
                OnShowMain();
            }
        }
    }

    public enum UIState
    {
        Main,
        Managers
    }
}
