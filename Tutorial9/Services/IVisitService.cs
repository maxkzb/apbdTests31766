using Tutorial9.Model.DTO;

namespace Tutorial9.Services
{
    public interface IVisitService
    {
        Task<VisitDTO> GetVisitByIdAsync(int visitId);
        Task<bool> AddVisitAsync(VisitDTO visitDto);
    }

    public interface IClientService
    {
        Task<ClientDTO> GetClientByIdAsync(int clientId);
    }

    public interface IMechanicService
    {
        Task<MechanicDTO> GetMechanicByLicenceAsync(string licenceNumber);
    }
}

