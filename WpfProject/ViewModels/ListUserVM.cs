using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Tools;
using WpfProject.WebModels;

namespace WpfProject.ViewModels
{
    public class ListUserVM : BaseTools
    {
        public User SelectedItem { get; set; }
        private List<User> user;

        public List<User> User
        {
            get => user;
            set
            {
                user = value;

                Signal();
            }
        }

        public CommandVM DeleteUser { get; set; }


        public ListUserVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Users", null, "ListUsers");
                User = HttpApi.Deserialize<List<User>>(json);

            });

            DeleteUser = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Users", SelectedItem.UserId, "delete");
            });

        }
    }
}
