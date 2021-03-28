using System.Collections.ObjectModel;

namespace CollectionBinding
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Names = new ObservableCollection<string>
            {
                "Dallas",
                "Valery",
                "Mozella",
                "Bryanna",
                "Enoch",
                "Gil",
                "Lu"
            };
        }

        public ObservableCollection<string> Names { get; set; }
    }
}