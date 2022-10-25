using System.Linq;
using System.Windows;
using MailSender.Infrastructure.Commands.Base;

namespace MailSender.Infrastructure.Commands
{
    internal class CloseWindowCommand:Command
    {
        protected override void Execute(object p)
        {
            var window = p as Window;

            if (window != null)
                window = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

            if(window != null)
                window = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

            window?.Close();
        }
    }
}
