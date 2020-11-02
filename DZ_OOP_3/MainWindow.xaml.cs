using System.Windows;


namespace DZ_OOP_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Функция, проверяющая состоит ли строка только из букв
        public static bool IsLettersOnly(string str)
        {
            foreach (char s in str)
            {
                if (s >= '0' && s <= '9')
                    return false;
            }
            return true;
        }
        //Функция, проверяющая введенный текст на латиницу
        public static bool IsLatin(string str)
        {
            str = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                if (!(str[i] >= 'A' && str[i] <= 'Z'))
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
            string Text = InputTextTB.Text.ToUpper(), Code = InputCodeTB.Text.ToUpper(), Result = "";
            if (EncRB.IsChecked == true)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if (Text[i] == ' ')
                    {
                        Result += " ";
                    }
                    else
                    {
                        Result += alphabet[(alphabet.IndexOf(Text[i]) + alphabet.IndexOf(Code[k % Code.Length]) + 1) % alphabet.Length];
                        k++;
                    }
                }
                OutputTB.Text = Result;
            }
            else if (DecRB.IsChecked == true)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if (Text[i] == ' ')
                    {
                        Result += " ";
                    }
                    else
                    {
                        Result += alphabet[(alphabet.IndexOf(Text[i]) + alphabet.Length - alphabet.IndexOf(Code[k % Code.Length]) - 1) % alphabet.Length];
                        k++;
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
            if (IsLettersOnly(InputTextTB.Text.ToUpper()) && IsLettersOnly(InputCodeTB.Text.ToUpper()))
            {
                if (IsLatin(InputTextTB.Text) == IsLatin(InputCodeTB.Text))
                {
                    if (KirRB.IsChecked == true || LatRB.IsChecked == true)
                    {
                        string alphabet;
                        if (KirRB.IsChecked == true && !IsLatin(InputTextTB.Text) && !IsLatin(InputCodeTB.Text))
                        {
                            alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                            MakeEncOrDec(alphabet);
                        }
                        else if (LatRB.IsChecked == true && IsLatin(InputTextTB.Text) && IsLatin(InputCodeTB.Text))
                        {
                            alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
                    MessageBox.Show("Ошибка! Текст и кодовое слово заданы в разных алфавитах");
                }
            }
            else
            {
                MessageBox.Show("Ошибка! В одной из введённых строк присутствует число.");
            }
        }
    }
}
