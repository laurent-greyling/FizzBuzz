using FizzBuzz.ViewModels;
using System.Text;
using Xamarin.Forms;

namespace FizzBuzz
{
	public partial class MainPage : ContentPage
	{
        public static PrintNumbersViewModel Number { get; set; }
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = "FizzBuzz";
        private bool? IsCorrect;

        public MainPage()
		{
			InitializeComponent();
            Number = new PrintNumbersViewModel();

            BindingContext = Number;
        }

        public void Select_Fizz(object sender, ClickedEventArgs e)
        {
            DisableButtons();
            var textValue = CheckNumber(int.Parse(MyNumber.Text));

            if (textValue == Fizz)
            {
                Success();
            }
            else
            {
                Failure(textValue);
            }
        }

        public void Select_Buzz(object sender, ClickedEventArgs e)
        {
            DisableButtons();
            var textValue = CheckNumber(int.Parse(MyNumber.Text));

            if (textValue == Buzz)
            {
                Success();
            }
            else
            {
                Failure(textValue);
            }
        }

        public void Select_FizzBuzz(object sender, ClickedEventArgs e)
        {
            DisableButtons();
            var textValue = CheckNumber(int.Parse(MyNumber.Text));

            if (textValue == FizzBuzz)
            {
                Success();
            }
            else
            {
                Failure(textValue);
            }
        }

        public void Select_None(object sender, ClickedEventArgs e)
        {
            DisableButtons();
            var textValue = CheckNumber(int.Parse(MyNumber.Text));

            if (string.IsNullOrEmpty(textValue))
            {
                Success();
            }
            else
            {
                Failure(textValue);
            }
        }

        public void Reset_Value()
        {            
            //TODO: When this is initialized it does it 5 times, putting incorrectcount to 5 when it should be 0. Fix.
            IsSuccess.Text = string.Empty;
            EnableButtons();
            if (IsCorrect != null)
            {
                if ((bool)IsCorrect)
                {
                    IsCorrect = false;
                }
                else
                {
                    SetIncorrectCount();
                }
            }
            else
            {
                SetIncorrectCount();
            }
        }

        private void DisableButtons()
        {
            FizzButton.IsEnabled = false;
            BuzzButton.IsEnabled = false;
            FizzBuzzButton.IsEnabled = false;
            NoneButton.IsEnabled = false;
        }

        private void EnableButtons()
        {
            FizzButton.IsEnabled = true;
            BuzzButton.IsEnabled = true;
            FizzBuzzButton.IsEnabled = true;
            NoneButton.IsEnabled = true;
        }

        private void Success()
        {
            IsSuccess.Text = "Correct";
            IsSuccess.TextColor = Color.Green;
            IsCorrect = true;
            var correctAnswers = int.Parse(CorrectCount.Text);
            correctAnswers++;
            CorrectCount.Text = correctAnswers.ToString();
        }

        private void Failure(string textValue)
        {
            IsSuccess.Text = !string.IsNullOrEmpty(textValue) ? $"Incorrect: Should be {textValue}" : "Incorrect";
            IsSuccess.TextColor = Color.Red;
            IsCorrect = false;
        }

        private void SetIncorrectCount()
        {
            var incorrectAnswers = string.IsNullOrEmpty(IncorrectCount.Text) ? 0 : int.Parse(IncorrectCount.Text);
            incorrectAnswers++;
            IncorrectCount.Text = incorrectAnswers.ToString();
        }

        private string CheckNumber(int number)
        {
            var fizzOrBuzz = new StringBuilder();

            if (number % 3 == 0)
            {
                fizzOrBuzz.Append(Fizz);
            }

            if (number % 5 == 0)
            {
                fizzOrBuzz.Append(Buzz);
            }

            return fizzOrBuzz.ToString();
        }
    }
}
