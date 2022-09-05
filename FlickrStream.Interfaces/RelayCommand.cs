using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrStream.Infrastructure
{
    /// <summary>
    /// Class to implement ICommand for command binding
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action commandAction;
        private bool canExecute;

        /// <summary>
        /// Creates an instance of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="workToDo">The action to be performed</param>
        /// <param name="isExecuteAllowed">True, if the action can be performed</param>
        public RelayCommand(Action workToDo, bool isExecuteAllowed)
        {
            commandAction = workToDo;
            canExecute = isExecuteAllowed;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            commandAction();
        }
    }
}
