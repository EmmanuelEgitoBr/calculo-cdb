namespace Calculo.Cdb.App.Api.Models
{
    public class CdbParameters
    {
        public RequestModel Model { get; set; }
        public double Cdi { get; private set; } = 1.08;
        public double Tb { get; private set; } = 0.009;

        public CdbParameters(RequestModel model) 
        {
            Model = model;
        }
    }
}