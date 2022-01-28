using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.XPath;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EDMICalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (button.Text == "." && Entry.Text.ToList().Last() == '.')
            {
                return;

            }
            if (Entry.Text == "0" && button.Text != ".")
            {
                Entry.Text = button.Text;
            }
            else
            {
                Entry.Text = Entry.Text + button.Text;
            }
        }

        private void Result_Clicked(object sender, EventArgs e)
        {
            this.Entry.Text = Evaluate(Entry.Text).ToString();
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            this.Entry.Text = "0";
        }
        public static double Evaluate(string expression)
        {
            var xsltExpression =
                string.Format("number({0})",
                    new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                            .Replace("/", " div ")
                                            .Replace("%", " mod ")
                                            .Replace(":", " div ")
                                            .Replace("x", " * "));

            return (double)new XPathDocument
                (new StringReader("<r/>"))
                    .CreateNavigator()
                    .Evaluate(xsltExpression);
        }
    }
}