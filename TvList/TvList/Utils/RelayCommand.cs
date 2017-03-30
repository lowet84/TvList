using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XLabs;

namespace TvList.Utils
{
    public class RelayCommand : ICommand
    {
        /// <summary>The _execute</summary>
        private readonly Action<object> _execute;
        /// <summary>The _can execute</summary>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XLabs.RelayCommand" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <exception cref="T:System.ArgumentNullException">execute</exception>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            if (canExecute == null)
                return;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class that
        /// can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
        public RelayCommand(Action<object> execute)
          : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute) :
            this((p) => execute.Invoke(), (p) => canExecute.Invoke())
        {

        }

        public RelayCommand(Action execute) : this((p) => { execute.Invoke(); }, null)
        {

        }

        /// <summary>Raises the can execute changed.</summary>
        public void RaiseCanExecuteChanged()
        {
            var canExecuteChanged = CanExecuteChanged;
            canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public virtual void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;
            _execute(parameter);
        }
    }
}
