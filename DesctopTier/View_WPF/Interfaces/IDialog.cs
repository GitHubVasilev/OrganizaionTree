using System;

namespace View_WPF.Interfaces
{
    public interface IDialog 
    {
        bool ResultDialog { get; }
        void OpenWindow();
    }
}
