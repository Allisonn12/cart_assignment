namespace carterAPI.Models
{
    public class Response
    {
        // Customer Table
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Endpoint end_point { get; set; }
        public List<Endpoint> list_point { get; set; }


        // Car table
        public carEndpoint car_point { get; set; }
        public List<carEndpoint> car_Endpoint { get; set; }

        // Purchases table
        public purchasesEndpoint purchase_point { get; set; }
        public List<purchasesEndpoint> purchase_Endpoint { get; set; }

        // Stored procedure
        public storedProcedure storedProcedure { get; set; }
        public List<storedProcedure> list_storedProcedure { get; set; }


    }
}
