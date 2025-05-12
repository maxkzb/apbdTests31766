namespace Tutorial9.Model.DTO
{
    public class VisitDTO
    {
        public DateTime VisitDate { get; set; }
        public ClientDTO Client { get; set; } = null!;
        public MechanicDTO Mechanic { get; set; } = null!;
        public List<VisitServiceDTO> VisitServices { get; set; } = new List<VisitServiceDTO>();
    }

    public class ClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class MechanicDTO
    {
        public int IdMechanic { get; set; }
        public string LicenceNumber { get; set; }
    }

    public class VisitServiceDTO
    {
        public string Name { get; set; }
        public string ServiceFee { get; set; }
    }
}