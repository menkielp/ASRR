using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRR.Core
{
    public interface IDialogManager
    {
        /// <summary>
        /// Pokazuje wiadomosc uzytkownikowi
        /// </summary>
        /// <param name="dialogBoxViewModel"></param>
        /// <returns></returns>
        Task ShowMessage(DialogBoxViewModel dialogBoxViewModel);

        /// <summary>
        /// Zamkniecie wiadomosci
        /// </summary>
        /// <param name="dialogBoxViewModel"></param>
        /// <returns></returns>
        Task CloseMessage(DialogBoxViewModel dialogBoxViewModel);
    }
}
