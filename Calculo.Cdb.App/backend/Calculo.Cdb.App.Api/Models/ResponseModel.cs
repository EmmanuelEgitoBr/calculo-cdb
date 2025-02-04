namespace Calculo.Cdb.App.Api.Models
{
    public class ResponseModel
    {
        public double GrossValue { get; set; }
        public double NetValue { get; set; }

        public ResponseModel(double grossValue, double netValue)
        {  
            GrossValue = grossValue; 
            NetValue = netValue; 
        }
    }
}