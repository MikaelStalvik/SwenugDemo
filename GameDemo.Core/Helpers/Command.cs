﻿using System;
using System.Windows.Input;

namespace PCL.Helpers
{
    public class Command : ICommand
    {
        #region Constructors

        public Command(Action<object> execute)
            : this(execute, null) { }

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #endregion

        private readonly Action<object> _execute = null;
        private readonly Predicate<object> _canExecute = null;
    }
}