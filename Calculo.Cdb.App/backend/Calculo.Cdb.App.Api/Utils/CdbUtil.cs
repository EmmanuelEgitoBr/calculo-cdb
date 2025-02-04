using Calculo.Cdb.App.Api.Models;
using System;

namespace Calculo.Cdb.App.Api.Utils
{
    public static class CdbUtil
    {
        public static ResponseModel CalculateGrossAndNetValues(CdbParameters parameters)
        {
            var grossValue = parameters.Model.InitialValue *
                (Math.Pow(1 + (parameters.Cdi * parameters.Tb), parameters.Model.Months));
            
            var profit = grossValue - parameters.Model.InitialValue;

            var netValue = grossValue - 
                (profit * (GetCdbTax(parameters.Model.Months) / 100));

            return new ResponseModel(Math.Round(grossValue, 2), Math.Round(netValue, 2));
        }

        private static double GetCdbTax(int numberMonths)
        {
            switch (numberMonths)
            {
                case int n when n <= 6:
                    return 22.5;
                case int n when n > 7 && n <= 12:
                    return 20;
                case int n when n > 12 && n <= 24:
                    return 17.5;
                default:
                    return 15;
            }
        }
    }
}