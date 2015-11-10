﻿using ContosoMoments.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContosoMoments.Views
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        async void OnLoginClicked(object sender, EventArgs e)
        {
            MobileServiceUser user;

            try
            {
                // The authentication provider could also be Facebook, Twitter, or Microsoft
                user = await DependencyService.Get<IMobileClient>().LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                App.AuthenticatedUser = user;
                Navigation.InsertPageBefore(new ImagesList(), this);
                await Navigation.PopAsync();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Authentication was cancelled"))
                {
                    messageLabel.Text = "Authentication cancelled by the user";
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Authentication failed";
            }
        }
    }
}