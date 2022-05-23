using OrtakHesap.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace OrtakHesap
{
    public class AppSettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Color baseColor = Color.FromHex("#2EC7A2");
        public Color BaseColor
        {
            get => baseColor;
            set
            {
                if (baseColor != value)
                {
                    baseColor = value;
                    OnPropertyChanged(nameof(BaseColor));
                }
            }
        }

        private Color secondColor = Color.FromHex("#A1B52C");
        public Color SecondColor
        {
            get => secondColor;
            set
            {
                if (secondColor != value)
                {
                    secondColor = value;
                    OnPropertyChanged(nameof(SecondColor));
                }
            }
        }
        private Color thirdColor = Color.FromHex("#59E7C4");
        public Color ThirdColor
        {
            get => thirdColor;
            set
            {
                if (thirdColor != value)
                {
                    thirdColor = value;
                    OnPropertyChanged(nameof(ThirdColor));
                }
            }
        }
        private int personCount = 3;
        public int PersonCount
        {
            get => personCount;
            set
            {
                if (personCount != value)
                {
                    personCount = value;
                    OnPropertyChanged(nameof(PersonCount));
                }
            }
        }



        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
