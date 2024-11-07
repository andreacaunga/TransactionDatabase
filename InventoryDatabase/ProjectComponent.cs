using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDatabase
{
    public partial class ProjectComponent : Component
    {
        public ProjectComponent()
        {
            InitializeComponent();
        }

        public ProjectComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }

    namespace UserAccountNamespace
    {
        abstract class UserAccount
        {
            private string firstName;
            private string lastName;
            protected string username;
            protected string password;

            public UserAccount(string firstName, string lastName, string username, string password)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.username = username;
                this.password = password;
            }
            public abstract bool validateLogin(string username, string password);

            public string getFirstName()
            {
                return firstName;
            }
            public string getLastName()
            {
                return lastName;
            }
        }

        class AdminRole : UserAccount
        {
            private string role;
            public AdminRole(string firstName, string lastName, string role, string username, string password) : base(firstName, lastName, username, password)
            {
                this.role = role;
            }
            public override bool validateLogin(string username, string password)
            {
                if (username == "admin" && password == "admin123")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
