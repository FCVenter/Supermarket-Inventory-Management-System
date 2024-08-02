using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace WoolworthsInventorySystem
{
    public partial class Login : Form
    {
        public class User // Wrapper class to identify users from textfile
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int AdminLevel { get; set; }
        }

        /// <summary>
        /// Authenticates a user based on their username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The plain text password of the user.</param>
        /// <returns>A User object if authentication is successful, null otherwise.</returns>
        public User Authenticate(string username, string password)
        {
            // Read each line from the users file.
            foreach (var line in File.ReadAllLines("users.txt"))
            {
                // Split the line into its components.
                var parts = line.Split('#');

                // Check if the username matches.
                if (parts.Length == 4 && parts[0] == username)
                {
                    // Hash the provided password with the stored salt.
                    var hashedInputPassword = PasswordHelper.HashPassword(password, parts[2]);

                    // Check if the hashed password matches the stored hash.
                    if (hashedInputPassword == parts[1])
                    {
                        // Return a new User object with the user's details.
                        return new User
                        {
                            Username = parts[0],
                            Password = parts[1],
                            AdminLevel = int.Parse(parts[3])
                        };
                    }
                }
            }

            // Return null if authentication fails.
            return null;
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to authenticate the user.
                var user = Authenticate(txtLoginUsername.Text, txtLoginPassword.Text);

                // Check if the user was authenticated successfully.
                if (user != null)
                {
                    switch (user.AdminLevel)
                    {
                        case 1:
                            StoreManagerDirectory ManagerForm = new StoreManagerDirectory(this);
                            ManagerForm.Show();
                            this.Hide();
                            break;
                        case 2:
                            new RequestReports(new StoreManagerDirectory(this), false).Show();
                            this.Hide();
                            break;
                        case 3:
                            new BuyProducts(this).Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("Invalid admin level.");
                            break;
                    }

                    txtLoginPassword.Clear();
                    txtLoginUsername.Clear();

                }
                else
                {
                    // Display an error message if authentication fails.
                    MessageBox.Show("Invalid credentials.");
                }
            }
            catch (Exception ex)
            {
                // Display a generic error message to the user.
                MessageBox.Show("An error occurred. Please try again later.");

                // Log the exception for debugging and analysis.
                // Consider using a logging library or service for this.
                // Example: Log.Error(ex);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtLoginUsername.Focus();
            this.ControlBox = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public static class PasswordHelper
    {
        /// <summary>
        /// Generates a unique salt for password hashing.
        /// </summary>
        /// <returns>A base64 encoded string representing the salt.</returns>
        public static string GenerateSalt()
        {
            // Create a byte array to hold the salt.
            byte[] saltBytes = new byte[32];

            // Use RNGCryptoServiceProvider for generating cryptographically secure random numbers.
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            // Convert the byte array to a base64 string and return.
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hashes a password with a given salt.
        /// </summary>
        /// <param name="password">The plain text password.</param>
        /// <param name="salt">The salt to use for hashing.</param>
        /// <returns>A base64 encoded string representing the hashed password.</returns>
        public static string HashPassword(string password, string salt)
        {
            // Use SHA256 for hashing the password.
            using (var sha256 = SHA256.Create())
            {
                // Combine the password and salt before hashing.
                var saltedPassword = password + salt;

                // Compute the hash of the salted password.
                byte[] saltedHashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Convert the byte array to a base64 string and return.
                return Convert.ToBase64String(saltedHashBytes);
            }
        }
    }

}
