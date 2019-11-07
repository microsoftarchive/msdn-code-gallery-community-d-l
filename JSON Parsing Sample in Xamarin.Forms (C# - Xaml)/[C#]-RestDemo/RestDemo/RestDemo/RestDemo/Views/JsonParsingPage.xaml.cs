using Newtonsoft.Json;
using RestDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonParsingPage : ContentPage
    {
        public JsonParsingPage()
        {
            InitializeComponent();
            GetJSON();
        }
        public async void GetJSON()
        {
            #region Sample Json
            /*
            {
                "contacts": [
                    {
            "id": "c200",
                            "name": "Ravi Tamada",
                            "email": "ravi@gmail.com",
                            "address": "xx-xx-xxxx,x - street, x - country",
                            "gender" : "male",
                            "phone": {
                "mobile": "+91 0000000000",
                                "home": "00 000000",
                                "office": "00 000000"
            }
},
    {
            "id": "c201",
            "name": "Johnny Depp",
            "email": "johnny_depp@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c202",
            "name": "Leonardo Dicaprio",
            "email": "leonardo_dicaprio@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c203",
            "name": "John Wayne",
            "email": "john_wayne@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c204",
            "name": "Angelina Jolie",
            "email": "angelina_jolie@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "female",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c205",
            "name": "Dido",
            "email": "dido@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "female",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c206",
            "name": "Adele",
            "email": "adele@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "female",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c207",
            "name": "Hugh Jackman",
            "email": "hugh_jackman@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c208",
            "name": "Will Smith",
            "email": "will_smith@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c209",
            "name": "Clint Eastwood",
            "email": "clint_eastwood@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c2010",
            "name": "Barack Obama",
            "email": "barack_obama@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c2011",
            "name": "Kate Winslet",
            "email": "kate_winslet@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "female",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    },
    {
            "id": "c2012",
            "name": "Eminem",
            "email": "eminem@gmail.com",
            "address": "xx-xx-xxxx,x - street, x - country",
            "gender" : "male",
            "phone": {
                "mobile": "+91 0000000000",
                "home": "00 000000",
                "office": "00 000000"
            }
    }
]
}*/
            #endregion



            //Check network status 
            if (NetworkCheck.IsInternet())
            {
             
                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("http://api.androidhive.info/contacts/");
                string contactsJson = response.Content.ReadAsStringAsync().Result;
                ContactList ObjContactList = new ContactList();
                if (contactsJson != "")
                {
                    //Converting JSON Array Objects into generic list
                    ObjContactList = JsonConvert.DeserializeObject<ContactList>(contactsJson);
                }
                //Binding listview with server response  
                listviewConacts.ItemsSource = ObjContactList.contacts;
            }
            else
            {
                await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }
            //Hide loader after server response  
            ProgressLoader.IsVisible = false;
        }
        
        private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelectedData = e.SelectedItem as Contact;
            Navigation.PushAsync(new JsonDetailsPage(itemSelectedData));
        }
    }
}
