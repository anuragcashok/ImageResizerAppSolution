﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageResizerApp.Commands
{
    /// <summary>
    /// Represents a command that can be executed.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The action to execute when the command is invoked.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// A function that determines whether the command can be executed.
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the RelayCommand class.
        /// </summary>
        /// <param name="execute">The action to execute when the command is invoked.</param>
        /// <param name="canExecute">A function that determines whether the command can be executed.</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Occurs when the CanExecute method of the command changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determines whether the command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter to pass to the CanExecute method.</param>
        /// <returns>True if the command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">The parameter to pass to the Execute method.</param>
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
