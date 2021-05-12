using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    class DishToAdd : INotifyPropertyChanged
    {
        private int _amount;
        private bool _isSelected;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Dish Dish { get; set; }

        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                if (value != 0)
                    IsSelected = true;
                else
                    IsSelected = false;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value && Amount == 0)
                    _isSelected = false;
                else if (value == false && Amount != 0)
                    _isSelected = true;
                else
                    _isSelected = value;
                OnPropertyChanged();
            }

        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
