using appwithtool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appwithtool.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            var scroll = new ScrollView();
            Content = scroll;
            var rvm = new RegistrationViewModel();
            this.BindingContext = rvm;
            rvm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Username or Password Already Exist, try again", "OK");

            InitializeComponent();

            Name.Completed += (object sender, EventArgs e) =>
            {
                PhoneNumber.Focus();
            };

            PhoneNumber.Completed += (object sender, EventArgs e) =>
            {
                Email.Focus();
            };

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                ConfirmPassword.Focus();
            };

            ConfirmPassword.Completed += (object sender, EventArgs e) =>
            {
                rvm.SubmitCommand.Execute(null);
            };
        }
    }
}
