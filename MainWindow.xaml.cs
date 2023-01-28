using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace ПрактическаяРабота1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            //Валидация 
            Regex regex = new Regex("@[0-9]+[.[0-9]+]?");
            if (regex.IsMatch(textBox2.Text))
            {
                MessageBox.Show("Ошибка ввода переменной");
            }
            if (regex.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Ошибка ввода переменной");
            }

            //Вводим две переменные для решения уравнения
            double x = Convert.ToDouble(textBox2.Text);
            double y = Convert.ToDouble(textBox1.Text);

            //Указываем, как должен выглядеть вывод
            textBox3.Text = "Результат работы программы" + " ст. Бушак.Е.Д. " + Environment.NewLine;
            textBox3.Text += "При X = " + textBox2.Text + Environment.NewLine;
            textBox3.Text += "При Y = " + textBox1.Text + Environment.NewLine;

            double X_Y = x - y; //Для упрощения написания условия
            double result; //Итоговый ответ

            //Условия проверки при выборе значений и вероятности ошибки со стороны пользователя
            if (RB1.IsChecked == true && X_Y == 0)
            {
                result = Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Sin(y);
                textBox3.Text += result.ToString() + Environment.NewLine;
            }
            else if (RB2.IsChecked == true && X_Y > 0)
            {
                result = x - Math.Pow(y, 2) + Math.Cos(y);
                textBox3.Text += result.ToString() + Environment.NewLine;
            }
            else if (RB3.IsChecked == true && X_Y < 0)
            {
                result = Math.Pow(y - x, 2) + Math.Tan(y);
                textBox3.Text += result.ToString() + Environment.NewLine;
            }
            else if (x == null)
            {
                MessageBox.Show("Вы забыли про переменную Х");
            }
            else if (y == null)
            {
                MessageBox.Show("Вы забыли про переменную Y");
            }
            else
            {
                MessageBox.Show("Невозможно решить при выбранном условии. Проверьте всё ещё раз");
                //textBox3.Text += "Выбранная Вами функция невозможна" + Environment.NewLine;
            }

        }
        //Возможность выбрать действие в списке
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
        }
        //Очищаем данные
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            RB1.IsChecked = false;
            RB2.IsChecked = false;
            RB3.IsChecked = false;

        }
        //Выход из приложения
        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBox.Show("Вы покидаете приложение");
            base.OnClosing(e);
        }

    }
}
