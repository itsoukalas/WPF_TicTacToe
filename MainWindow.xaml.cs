using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  string  value= "x";
        private int xWins = 0;
        private int yWins = 0;
        private static readonly Brush DEFAULTBRUSH = new SolidColorBrush(Color.FromArgb(255, 142, 142, 166));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            xWins = 0;
            yWins = 0;
            lblXWins.Content = "x: 0";
            lblYWins.Content = "y: 0";

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is my TicTacToe \n created my me!","TicTacToe",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Black;
            bt.IsEnabled = false;

           

            if (IsWin(btA1,btA2,btA3)) GameOver(btA1.Content.ToString());
            if (IsWin(btB1,btB2,btB3)) GameOver(btB1.Content.ToString());
            if (IsWin(btC1,btC2,btC3)) GameOver(btC1.Content.ToString());

            if (IsWin(btA1,btB1,btC1)) GameOver(btA1.Content.ToString());
            if (IsWin(btA2,btB2,btC2)) GameOver(btA2.Content.ToString());
            if (IsWin(btA3,btB3,btC3)) GameOver(btA3.Content.ToString());

            if (IsWin(btA1,btB2,btC3)) GameOver(btA1.Content.ToString());
            if (IsWin(btA3,btB2,btC1)) GameOver(btA3.Content.ToString());

            if (!btA1.IsEnabled && !btA2.IsEnabled && !btA3.IsEnabled &&
          !btB1.IsEnabled && !btB2.IsEnabled && !btB3.IsEnabled &&
           !btC1.IsEnabled && !btC2.IsEnabled && !btC3.IsEnabled)
                GameOver("");

            value = value == "X" ? "Y" : "X";
        }

        private void GameOver(string who)
        {
            if (lblWinner.Visibility==Visibility.Visible) return;

            if (who == "X")
            {
                lblWinner.Content = "Player X Win!";
                lblXWins.Content = $"X: {++xWins}";
            }
            else
            if (who == "Y")
            {
                lblWinner.Content = "Player Y Win!";
                lblYWins.Content = $"Y: {++yWins}";
            }
            else lblWinner.Content = "No winner!";
            lblWinner.Visibility =Visibility.Visible;
            wait1SecAndStart();
        }

        private async void wait1SecAndStart()
        {
            await Task.Delay(1000);
            lblWinner.Visibility = Visibility.Hidden;
            ResetButtons();
        }

        private void ResetButtons()
        {
            ResetButton(btA1);
            ResetButton(btA2);
            ResetButton(btC3); 
            ResetButton(btB1);
            ResetButton(btB2);
            ResetButton(btB3); 
            ResetButton(btC1);
            ResetButton(btC2);
            ResetButton(btC3);
        }

        private void ResetButton(Button btA1)
        {
            btA1.Content = "";
            btA1.IsEnabled = true;
            btA1.Foreground = DEFAULTBRUSH;
        }

        private bool IsWin(Button bt1, Button bt2, Button bt3) => !bt1.IsEnabled && bt1.Content == bt2.Content && bt1.Content == bt3.Content;

        private void bt_Enter(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content = value;
        }

        private void bt_Leave(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled) bt.Content = "";
        }
    }
}
