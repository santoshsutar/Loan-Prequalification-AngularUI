using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ProEnt.LoanPrequalification.Service.ServiceImplementations
{
    public class Helper
    {
        private static Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

        internal static bool IsGuid(string candidate)
        {
            bool isValid = false;
            
            if (candidate != null)
            {

                if (isGuid.IsMatch(candidate))
                {                    
                    isValid = true;
                }
            }
            return isValid;
        }

    }
}
