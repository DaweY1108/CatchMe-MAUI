using Microsoft.Maui.Controls.Internals;

namespace CatchMe
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Random random = new Random();
        ImageButton currentButton;
        List<string> buttonNames = new List<string>();

        [Obsolete]
        public MainPage()
        {
            InitializeComponent();
            textBox.Text = "Pontszám: 0";
            InitializeButtonNames();
            StartGame();
            Device.StartTimer(TimeSpan.FromSeconds(0.5), () =>
            {
                StartGame();
                return true; 
            });
        }

        void InitializeButtonNames()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    string buttonName = "button" + row + column;
                    buttonNames.Add(buttonName);
                }
            }
        }

        void StartGame()
        {
            if (currentButton != null)
                currentButton.Source = null;
            int randomIndex = random.Next(buttonNames.Count);
            string buttonName = buttonNames[randomIndex];
            currentButton = this.FindByName<ImageButton>(buttonName);
            try
            {
                currentButton.Source = "cat.png";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (string name in buttonNames)
            {
                ImageButton button = this.FindByName<ImageButton>(name);
            }
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;

            if (clickedButton == currentButton)
            {
                count++;
                textBox.Text = "Pontszám: " + count;
                
                currentButton.Source = null;
                StartGame();
            }
        }

    }

}
