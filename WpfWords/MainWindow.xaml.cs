using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Флаг того, что с полем для ввода слов уже контактировали (разделение текста)
        /// </summary>
        private bool textDivideTextBoxClicked;
        /// <summary>
        /// Флаг того, что с полем для ввода слов уже контактировали (отражение текста)
        /// </summary>
        private bool textReverseTextBoxClicked;

        /// <summary>
        /// Конструктор основного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            textDivideTextBoxClicked = false;
            textReverseTextBoxClicked = false;
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.6);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.6);
        }

        /// <summary>
        /// Преобразует текст в массив слов при помощи метода Split
        /// </summary>
        /// <param name="text">Исхордный текст</param>
        /// <returns>Массив из слов исходного текста</returns>
        private static string[] ArrayFromTextSplit(string text)
        {
            return text.Split(' ');
        }

        /// <summary>
        /// Возвращает слова текста задом наперед
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <returns>Слова текста задом наперед</returns>
        private static string ReverseText(string text)
        {
            string result = "";
            string[] array = ArrayFromTextSplit(text);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                result += array[i] + " ";
            }
            return result;
        }

        /// <summary>
        /// Удаляет текст из поля ввода, если по нему кликают в первый раз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextDivideTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!textDivideTextBoxClicked)
            {
                TextDivideTextBox.Text = string.Empty;
                textDivideTextBoxClicked = true;
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку Разделить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextDivideButton_Click(object sender, RoutedEventArgs e)
        {
            TextDivideListBox.ItemsSource = new List<string>(ArrayFromTextSplit(TextDivideTextBox.Text));
        }

        /// <summary>
        /// Удаляет текст из поля ввода, если по нему кликают в первый раз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseTextTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!textReverseTextBoxClicked)
            {
                ReverseTextTextBox.Text = string.Empty;
                textReverseTextBoxClicked = true;
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку Отразить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseTextButton_Click(object sender, RoutedEventArgs e)
        {
            ReverseTextLabel.Content = ReverseText(ReverseTextTextBox.Text);
        }
    }
}
