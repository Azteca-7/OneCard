using Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cards.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard : ContentPage
    {
        List<object> collectionAux = new List<object>();
        public Dashboard(object item)
        {
            try
            {
                InitializeComponent();
                List<object> collection = new List<object>();
                collection.Add(item);
                collectionAux = collection;
             
                IEnumerable<Balance> list = collection.Cast<Balance>();
                foreach (var v in list)
                {
                    var vop = v.Data;
                    var res = vop.Balance;
                    Saldocard.Text = res.ToString();

                }
            }
            catch(Exception ex)
            {
                var error = ex.ToString();
            }
        }



        public Dashboard ()
		{
			InitializeComponent ();
		}
        
    }
}