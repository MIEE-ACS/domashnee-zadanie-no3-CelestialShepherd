using System;
using System.Windows;


namespace DZ_OOP_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Функция, проверяющая введенный текст на латиницу
        public static bool IsLatin(string str)
        {
            str = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'А' && str[i] <= 'Я')
                {
                    return false;
                }
            }
            return true;
        }
        // Функция, выполняющая шифрование и расшифрование
        public void MakeEncOrDec(string alphabet)
        {  
            int k = 0;
            string Text = InputTextTB.Text, Code = InputCodeTB.Text.ToLower(), Result = "";
            if (EncRB.IsChecked == true)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if ((Text[i] >= 'а' && Text[i] <= 'я') ||  (Text[i] >= 'a' && Text[i] <= 'z'))
                    {
                        Result += alphabet[(alphabet.IndexOf(Text[i]) + alphabet.IndexOf(Code[k % Code.Length]) + 1) % alphabet.Length];
                        k++;
                    }
                    else if ((Text[i] >= 'А' && Text[i] <= 'Я') || (Text[i] >= 'A' && Text[i] <= 'Z'))
                    {
                        Result += Char.ToUpper(alphabet[(alphabet.IndexOf(Char.ToLower(Text[i])) + alphabet.IndexOf(Code[k % Code.Length]) + 1) % alphabet.Length]);
                        k++;
                    }
                    else
                    {
                        Result += Text[i];
                    }
                }
                OutputTB.Text = Result;
            }
            else if (DecRB.IsChecked == true)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if ((Text[i] >= 'а' && Text[i] <= 'я') || (Text[i] >= 'a' && Text[i] <= 'z'))
                    {
                        Result += alphabet[(alphabet.IndexOf(Text[i]) + alphabet.Length - alphabet.IndexOf(Code[k % Code.Length]) - 1) % alphabet.Length];
                        k++;
                    }
                    else if ((Text[i] >= 'А' && Text[i] <= 'Я') || (Text[i] >= 'A' && Text[i] <= 'Z'))
                    {
                        Result += Char.ToUpper(alphabet[(alphabet.IndexOf(Char.ToLower(Text[i])) + alphabet.Length - alphabet.IndexOf(Code[k % Code.Length]) - 1) % alphabet.Length]);
                        k++;
                    }
                    else
                    {
                        Result += Text[i];
                    }
                }
                OutputTB.Text = Result;
            }
            else
            {
                MessageBox.Show("Ошибка! Не был выбран вариант действия.");
            }
        }

        private void ActionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextTB.Text.Length != 0 && InputCodeTB.Text.Length != 0)
            {
                if (IsLatin(InputTextTB.Text) == IsLatin(InputCodeTB.Text))
                {
                    if (KirRB.IsChecked == true || LatRB.IsChecked == true)
                    {
                        string alphabet;
                        if (KirRB.IsChecked == true && !IsLatin(InputTextTB.Text) && !IsLatin(InputCodeTB.Text))
                        {
                            alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                            MakeEncOrDec(alphabet);
                        }
                        else if (LatRB.IsChecked == true && IsLatin(InputTextTB.Text) && IsLatin(InputCodeTB.Text))
                        {
                            alphabet = "abcdefghijklmnopqrstuvwxyz";
                            MakeEncOrDec(alphabet);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка! Выбранный алфавит и алфавит введенных данных различаются.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка! Не был выбран язык.");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка! Текст и кодовое слово заданы в разных алфавитах.");
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Не были введены данные.");
            }
        }
    }
}
