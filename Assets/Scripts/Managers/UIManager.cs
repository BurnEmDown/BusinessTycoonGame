using System;
using Balance;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private GameManager gameManager => GameManager.Instance;

        [SerializeField] private BalanceController balanceController;

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
        }

    }
}
