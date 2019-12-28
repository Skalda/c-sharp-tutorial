using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Attributes
{
    [Obsolete("MyClass is obsolete. Use MyClass2 instead.")]
    public class MyClass
    {
        
    }
    
    [MySpecial]
    public class MyClass2
    {
        
    }
    
    public class MyUIClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string Name 
        {
            get { return _name;}
            set 
            {
                if (value != _name) 
                {
                    _name = value;
                    RaisePropertyChanged();   // notice that "Name" is not needed here explicitly
                }
            }
        }
    }
}