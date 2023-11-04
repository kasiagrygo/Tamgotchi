using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tamgotchi
{
    public class LoginWindow : Window
    {
        private readonly View _parent;
        public Action<bool> OnLogin { get; set; }
        public Action OnExit { get; set; }

        public LoginWindow(View parent) : base("Login", 5)
        {
            _parent = parent;
            InitControls();
            InitStyle();
        }

        public void InitStyle()
        {
            X = Pos.Center();
            Width = Dim.Percent(50);
            Height = Dim.Percent(100);
        }

        public void Close()
        {
            Application.RequestStop();
            _parent?.Remove(this);
        }

        private void InitControls()
        {
            var nameLabel = new Label(0, 0, "Nickname");
            var nameText = new TextField("")
            {
                X = Pos.Left(nameLabel),
                Y = Pos.Top(nameLabel) + 1,
                Width = Dim.Fill()
            };
            Add(nameLabel);
            Add(nameText);

            var birthLabel = new Label("Birthday")
            {
                X = Pos.Left(nameText),
                Y = Pos.Top(nameText) + 1
            };
            var birthText = new TextField("")
            {
                X = Pos.Left(birthLabel),
                Y = Pos.Top(birthLabel) + 1,
                Width = Dim.Fill()
            };
            Add(birthLabel);
            Add(birthText);

            var tokenLabel = new Label("Tokens")
            {
                X = Pos.Left(birthText),
                Y = Pos.Top(birthText) + 1
            };
            var tokenText = new TextField("")
            {
                X = Pos.Left(tokenLabel),
                Y = Pos.Top(tokenLabel) + 1,
                Width = Dim.Fill()
            };
            Add(tokenLabel);
            Add(tokenText);

            var loginButton = new Button("Login", true)
            {
                X = Pos.Left(tokenText),
                Y = Pos.Top(tokenText) + 1
            };

            var exitButton = new Button("Exit")
            {
                X = Pos.Right(loginButton) + 5,
                Y = Pos.Top(loginButton)
            };

            Add(loginButton);
            Add(exitButton);

            loginButton.Clicked += () =>
            {
                if (nameText.Text.ToString().TrimStart().Length == 0)
                {
                    MessageBox.ErrorQuery(25, 8, "Error", "Name cannot be empty.", "Ok");
                    return;
                }

                var isDateValid = DateTime.TryParse(birthText.Text.ToString(), out DateTime birthDate);

                if (string.IsNullOrEmpty(birthText.Text.ToString()) || !isDateValid)
                {
                    MessageBox.ErrorQuery(25, 8, "Error", "Date is required\nor is invalid.", "Ok");
                    return;
                }

                int Age = CalculateAgeCorrect(birthDate, DateTime.Now);

                if (Age < 18)
                {
                    if (Age > 0)
                    {
                        MessageBox.ErrorQuery(25, 8, "Error", $"You have {Age} years. You are too young to play casino games.", "Ok");
                        return;
                    }
                    else
                    {
                        MessageBox.ErrorQuery(25, 8, "Error", $"You have {Age} years. You weren't even borned yet.", "Ok");
                        return;
                    }

                }
                if (Age > 100)
                {
                    MessageBox.ErrorQuery(25, 8, "Error", $"You have {Age} years. It can't be possible, please enter your real age.", "Ok");
                    return;
                }

                if (!double.TryParse(tokenText.Text.ToString(), out double value) || value <= 0)
                {
                    MessageBox.ErrorQuery(25, 8, "Error", "Token ammount is invalid.", "Ok");
                    return;
                }

         
                OnLogin?.Invoke(true);

                Close();
            };

            exitButton.Clicked += () =>
            {
                OnExit?.Invoke();
                Close();
            };
        }

        private int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }
    }
}

