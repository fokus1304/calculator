using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace calc;

public partial class MainWindow : Window
{
    private TextBox display;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        display = this.FindControl<TextBox>("Display");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            display.Text += button.Content.ToString();
        }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        display.Text = "";
    }

    private void Calculate_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = EvaluateExpression(display.Text);
            display.Text = result.ToString();
        }
        catch (Exception)
        {
            display.Text = "Error";
        }
    }

    private double EvaluateExpression(string expression)
    {
        return Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
    }

    private void SquareRoot_Click(object sender, RoutedEventArgs e)
    {
        display.Text = Math.Sqrt(double.Parse(display.Text)).ToString();
    }

    private void Power_Click(object sender, RoutedEventArgs e)
    {
        display.Text = Math.Pow(double.Parse(display.Text), 2).ToString();
    }

    private void Sin_Click(object sender, RoutedEventArgs e)
    {
        display.Text = Math.Sin(double.Parse(display.Text)).ToString();
    }

    private void Cos_Click(object sender, RoutedEventArgs e)
    {
        display.Text = Math.Cos(double.Parse(display.Text)).ToString();
    }

    private void Tan_Click(object sender, RoutedEventArgs e)
    {
        display.Text = Math.Tan(double.Parse(display.Text)).ToString();
    }
    private void Percentage_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = double.Parse(display.Text) / 100;
            display.Text = result.ToString();
        }
        catch (Exception)
        {
            display.Text = "Error";
        }
    }
    private double Factorial(double n)
    {
        if (n < 0)
            throw new ArgumentException ("‘акториал не определен дл€ отрицательных чисел");

        if (n == 0)
            return 1;
        else
            return n * Factorial(n - 1);
    }
    private void Factorial_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = Factorial(double.Parse(display.Text));
            display.Text = result.ToString();
        }
        catch (Exception)
        {
            display.Text = "Error";
        }
    }
  private void Log_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = Math.Log(double.Parse(display.Text),10);
            display.Text = result.ToString();
        }
        catch (Exception)
        {
            display.Text = "Error";
        }
    }

}


