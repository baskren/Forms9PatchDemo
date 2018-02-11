using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forms9PatchDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamlCDATA : ContentPage
    {
        public XamlCDATA()
        {
            InitializeComponent();

            PhoneLabel.ActionTagTapped += ActionTagTapped;
            EmailLabel.ActionTagTapped += ActionTagTapped;


        }

        private void ActionTagTapped(object sender, Forms9Patch.ActionTagEventArgs e)
        {
            var uri = new Uri(e.Href);
            Device.OpenUri(uri);
        }
    }
}