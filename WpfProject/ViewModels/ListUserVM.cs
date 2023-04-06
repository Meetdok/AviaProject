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


        public ListUserVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.GetInstance().Post("Users", "ListUsers", null);
                User = HttpApi.GetInstance().Deserialize<List<User>>(json);

            });
        }
    }
}
