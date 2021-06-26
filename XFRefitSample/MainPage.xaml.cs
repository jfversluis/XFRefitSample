using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XFRefitSample
{
    public partial class MainPage : ContentPage
    {
        private bool initialized = false;
        public ObservableCollection<TodoItem> TodoItems { get; set; } = new ObservableCollection<TodoItem>();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!initialized)
            {
                await GetTodoItems();
                initialized = true;
            }
        }

        private async Task GetTodoItems()
        {
            using (var httpClient = new HttpClient())
            {
                var todoJson = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
                var todoItems = JsonConvert.DeserializeObject<TodoItem[]>(todoJson);

                foreach(var item in todoItems)
                {
                    TodoItems.Add(item);
                }
            }
        }
    }
}
