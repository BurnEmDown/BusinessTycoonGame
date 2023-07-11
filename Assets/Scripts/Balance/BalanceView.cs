using TMPro;

namespace Balance
{
    public class BalanceView
    {
        private TMP_Text balanceText;
        
        public BalanceView(TMP_Text balanceText)
        {
            this.balanceText = balanceText;
        }

        public void UpdateBalanceUI(float balance)
        {
            balanceText.text = "$" + $"{balance:0.00}";
        }
    }
}